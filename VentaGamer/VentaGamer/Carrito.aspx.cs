using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace VentaGamer
{
    public partial class Carrito : System.Web.UI.Page
    {
        NegocioCarrito negCarrito = new NegocioCarrito();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                rptCarrito.DataSource = (DataTable)Session["Carrito"];
                rptCarrito.DataBind();
                vaciarCarrito.Visible = true;
            }
            else
            {
                lblRptCarritoVacio.Visible = true;
                lnkContinuarCompra.Visible = false;
                lnkSeguirComprando.Visible = false;
            }

            decimal total = 0;
            foreach (RepeaterItem item in rptCarrito.Items)
            {
                decimal precioUnidad = Convert.ToDecimal(((Label)item.FindControl("rptPrecioItem")).Text);
                decimal cantidad = Convert.ToDecimal(((TextBox)item.FindControl("txtCantidadProducto")).Text);
                decimal precio = precioUnidad * cantidad;
                ((Label)item.FindControl("lblPrecioProducto")).Text = precio.ToString();
                total += precio;
                lblTotalCarrito.Text = $"TOTAL: ${total}";
            }
        }

        protected void lnkConfirmarVaciar_Click(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                Session["Carrito"] = null;
            }

            Response.Redirect(Request.RawUrl);
        }
        
        protected void btnSumarCantidad_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(rptItemIndex.Value);
            DataTable tablaCarrito = (DataTable)Session["Carrito"];

            tablaCarrito.Rows[index]["Cantidad"] = Convert.ToInt32(tablaCarrito.Rows[index]["Cantidad"]) + 1;

            Session["Carrito"] = tablaCarrito;

            Response.Redirect(Request.RawUrl);
        }

        protected void btnRestarCantidad_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(rptItemIndex.Value);
            DataTable tablaCarrito = (DataTable)Session["Carrito"];


            if(Convert.ToInt32(tablaCarrito.Rows[index]["Cantidad"]) > 1)
            {
                tablaCarrito.Rows[index]["Cantidad"] = Convert.ToInt32(tablaCarrito.Rows[index]["Cantidad"]) - 1;
            }
            else
            {
                tablaCarrito.Rows[index]["Cantidad"] = 1;
            }

            Session["Carrito"] = tablaCarrito;

            Response.Redirect(Request.RawUrl);
        }

        protected void lnkQuitarProducto_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(rptItemIndex.Value);
            DataTable tablaCarrito = (DataTable)Session["Carrito"];

            negCarrito.eliminarFila(tablaCarrito, index);

            Session["Carrito"] = tablaCarrito;

            if(((DataTable)Session["Carrito"]).Rows.Count == 0)
            {
                Session["Carrito"] = null;
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void btnACtualizarCantidad_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(rptItemIndex.Value);
            DataTable tablaCarrito = (DataTable)Session["Carrito"];
            int cantidad = Convert.ToInt32(rptItemCantidad.Value);

            if (cantidad < 1) cantidad = 1;

            tablaCarrito.Rows[index]["Cantidad"] = cantidad;

            Session["Carrito"] = tablaCarrito;

            Response.Redirect(Request.RawUrl);
        }
    }
}