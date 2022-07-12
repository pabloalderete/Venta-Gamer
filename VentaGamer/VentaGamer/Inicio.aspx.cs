using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Collections;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace VentaGamer
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected NegocioProducto negProducto = new NegocioProducto();
        protected NegocioCarrito negCarrito = new NegocioCarrito();
        PagedDataSource pdsData = new PagedDataSource();
        protected int iPageSize = 12;
        protected void Page_Load(object sender, EventArgs e)
        {
            getProductos();
        }

        private void getProductos()
        {            
            DataTable dt = negProducto.getProductosActivos();

            if (Request.Params["IdCategoria"] != null)
            {
                int id = Convert.ToInt32(Request.Params["IdCategoria"]);
                Categoria categoria = new Categoria(id);

                dt = negProducto.getProductosPorCategoria(categoria);

            }
            else if (Request.Params["IdMarca"] != null)
            {
                int id = Convert.ToInt32(Request.Params["IdMarca"]);
                Marca marca = new Marca(id);

                dt = negProducto.getProductosPorMarca(marca);
            }
            else if (Request.Params["q"] != null)
            {
                dt = negProducto.getProductosBuscador(Request.Params["q"].ToString());
            }

            DataView dv = new DataView(dt);
            pdsData.DataSource = dv;
            pdsData.AllowPaging = true;
            pdsData.PageSize = iPageSize;
            if (ViewState["PageNumber"] != null)
            {
                pdsData.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]);
            }
            else
            {
                pdsData.CurrentPageIndex = 0;
            }

            activarODesactivarBotones();

            if (pdsData.PageCount > 1)
            {
                ArrayList alPages = new ArrayList();
                lnkPrevious.Visible = true;
                lnkNext.Visible = true;
                rptPagination.Visible = true;

                for (int i = 0; i < pdsData.PageCount; i++)
                {
                    alPages.Add(i);
                }

                rptPagination.DataSource = alPages;
                rptPagination.DataBind();
            }
            else
            {
                lnkPrevious.Visible = false;
                lnkNext.Visible = false;
                rptPagination.Visible = false;
            }

            rptProductos.DataSource = pdsData;
            rptProductos.DataBind();
        }

        private void activarODesactivarBotones()
        {
            if (pdsData.IsFirstPage)
            {
                liPrevious.Attributes["class"] += " disabled";
                lnkPrevious.Enabled = false;
            }
            else
            {
                liPrevious.Attributes["class"] = liPrevious.Attributes["class"].Replace("disabled", "");
                lnkPrevious.Enabled = true;
            }

            if (pdsData.IsLastPage)
            {
                liNext.Attributes["class"] += " disabled"; ;
                lnkNext.Enabled = false;
            }
            else
            {
                liNext.Attributes["class"] = liNext.Attributes["class"].Replace("disabled", "");
                lnkNext.Enabled = true;
            }
        }

        protected void lnkAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Producto producto = enlazarDatos();

                if (Session["Carrito"] == null)
                {
                    Session["Carrito"] = negCarrito.crearTabla();
                }

                if (!negCarrito.estaRepetido((DataTable)Session["Carrito"], producto.Id))
                {
                    negCarrito.agregarFila((DataTable)Session["Carrito"], producto);
                    Response.Redirect("~/AgregadoACarrito.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmsjeProductoEnCarrito", "msjeProductoEnCarrito()", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmsjeInicioSesion", "msjeInicioSesion()", true);
            }


        }

        private Producto enlazarDatos()
        {
            int id = Convert.ToInt32(idProducto.Value);
            Producto producto = new Producto(id);
            DataTable tablaProducto = negProducto.getProducto(producto);
            producto.llenar(tablaProducto);

            return producto;
        }


        protected void rptPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument);
            getProductos();
        }

        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(ViewState["PageNumber"]) - 1;
            getProductos();
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(ViewState["PageNumber"]) + 1;
            getProductos();
        }
    }
}