using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace VentaGamer
{
    public partial class HistorialDeVentas : System.Web.UI.Page
    {
        NegocioFactura negFactura = new NegocioFactura();
        NegocioDetalleFactura negDetalleFactura = new NegocioDetalleFactura();
        PagedDataSource pdsData = new PagedDataSource();
        protected int iPageSize = 5;
        
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

            getHistorialVentas();
        }

        private void getHistorialVentas()
        {
            DataTable dt = negFactura.getFacturasUsuariosTiposPago();
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

            rptFacturas.DataSource = pdsData;
            rptFacturas.DataBind();
        }

        protected void rptFacturas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl span = (HtmlGenericControl)e.Item.FindControl("idFactura");
                int idFactura = Convert.ToInt32(span.InnerText);
                DetalleFactura detalleFactura = new DetalleFactura(idFactura);
                Repeater rptDetalleFactura = (Repeater)e.Item.FindControl("rptDetalleFactura");

                rptDetalleFactura.DataSource = negDetalleFactura.getDetalleDeFacturaProductos(detalleFactura);
                rptDetalleFactura.DataBind();
            }
        }

        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(ViewState["PageNumber"]) - 1;
            getHistorialVentas();
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(ViewState["PageNumber"]) + 1;
            getHistorialVentas();
        }

        protected void rptPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument);
            getHistorialVentas();
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
    }
}