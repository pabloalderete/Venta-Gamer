using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace VentaGamer
{
    public partial class AgregadoACarrito : System.Web.UI.Page
    {
        NegocioProducto negProducto = new NegocioProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Carrito"] != null)
            {
                int ultimaFila = ((DataTable)Session["Carrito"]).Rows.Count - 1;
                int idUltimoAgregado = Convert.ToInt32(((DataTable)Session["Carrito"]).Rows[ultimaFila]["IdProducto"].ToString());
                Producto producto = new Producto(idUltimoAgregado);
                DataTable tablaUltimoAgregado = negProducto.getProducto(producto);

                rptAgregadoACarrito.DataSource = tablaUltimoAgregado;
                rptAgregadoACarrito.DataBind();
            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }
        }
    }
}