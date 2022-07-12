using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace VentaGamer
{
    public partial class EliminarProducto : System.Web.UI.Page
    {
        NegocioProducto negProducto = new NegocioProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null) // Usuario logueado
            {
                bool permiso = Convert.ToBoolean(((DataTable)Session["Usuario"]).Rows[0]["Permiso_Us"]);
                if (!permiso)
                {
                    Response.Redirect("~/Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }
        }

        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Id = Convert.ToInt32(txtEliminarProducto.Text);
            negProducto.deleteProducto(producto);
        }
    }
}