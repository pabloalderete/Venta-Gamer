using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace VentaGamer
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        NegocioCategoria negCatagoria = new NegocioCategoria();
        NegocioMarca negocioMarca = new NegocioMarca();
        protected string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null) // Usuario logueado
            {
                btnSesion.Visible = false;
                imgPerfil.ImageUrl = ((DataTable)Session["Usuario"]).Rows[0]["ImagenPerfil_Us"].ToString();
                imgPerfil.Visible = true;
            }
            else
            {
                btnSesion.Visible = true;
                imgPerfil.Visible = false;
            }

            //MENU ADMINISTRADOR
            if (Session["Usuario"] != null) // Usuario logueado
            {
                bool permiso = Convert.ToBoolean(((DataTable)Session["Usuario"]).Rows[0]["Permiso_Us"]);
                if (permiso)
                {
                    adminMenu.Visible = true;
                }
                else
                {
                    adminMenu.Visible = false;
                }
            }
            else
            {
                adminMenu.Visible = false;
            }

            //CATEGORIAS
            rptCategorias.DataSource = negCatagoria.getCategorias();
            rptCategorias.DataBind();

            //MARCAS
            rptMarcas.DataSource = negocioMarca.getMarcas();
            rptMarcas.DataBind();

            //CANTIDAD PRODUCTOS EN CARRITO
            if (Session["Carrito"] != null)
            {
                lblCantidadCarrito.InnerText = ((DataTable)Session["Carrito"]).Rows.Count.ToString();
            }
            else
            {
                lblCantidadCarrito.InnerText = "0";
            }

            //DESACTIVAR BOTON MENU
            btnMenu.Visible = false;

            switch (currentUrl)
            {
                case "/Inicio.aspx":
                    btnMenu.Visible = true;
                    break;
                case "/SeleccionarModificarProducto.aspx":
                    btnMenu.Visible = true;
                    break;
                default:
                    btnMenu.Visible = false;
                    break;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if(Session["Usuario"] != null)
            {
                Session["Usuario"] = null;
            }

            if(Session["Carrito"] != null)
            {
                Session["Carrito"] = null;
            }

            Response.Redirect("~/InicioSesion.aspx");
        }

        protected void btnBuscador_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (txtBusqueda.Text.Trim().Length != 0)
                {
                    switch (currentUrl)
                    {
                        case "/Inicio.aspx":
                        case "/SeleccionarModificarProducto.aspx":
                            Response.Redirect($"~/{currentUrl}?q={txtBusqueda.Text}");
                            break;
                        default:
                            Response.Redirect($"~/Inicio.aspx?q={txtBusqueda.Text}");
                            break;
                    }
                }
            }
        }

        protected void rptCategorias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["PageNumber"] = 0;
            Response.Redirect(Request.RawUrl);
        }

        protected void imgBtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }

        protected void lnkHistorialVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HistorialDeVentas.aspx");
        }

        protected void lnkReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes.aspx");
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            if(Session["Usuario"] != null)
            {
                Response.Redirect("~/Carrito.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallmsjeInicioSesion", "msjeInicioSesion()", true);
            }
        }

        protected void cuvTxtBusqueda_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool sizeIsValid = false;
            int size = txtBusqueda.Text.Trim().Length;

            if (size <= 100)
            {
                sizeIsValid = true;
            }

            if (sizeIsValid)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}