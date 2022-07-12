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
    public partial class Reportes : System.Web.UI.Page
    {
        NegocioFactura negFactura = new NegocioFactura();
        NegocioDetalleFactura negDetalle = new NegocioDetalleFactura();
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

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text.Trim().Length != 0 && txtFechaFin.Text.Trim().Length != 0)
            {
                string inicio = DateTime.Parse(txtFechaInicio.Text).ToString("yyyy/MM/dd");
                string fin = DateTime.Parse(txtFechaFin.Text).ToString("yyyy/MM/dd");
                divMontoIngreso.Visible = true;
                lblMontoIngreso.Text = $"${negFactura.getMontoIngreso(inicio, fin)}";
            }

        }

        protected void btnGenerarReporte_TPV_Click(object sender, EventArgs e)
        {
            if (txtFechaInicio_TPV.Text.Trim().Length != 0 && txtFechaFin_TPV.Text.Trim().Length != 0)
            {
                string inicio = DateTime.Parse(txtFechaInicio_TPV.Text).ToString("yyyy/MM/dd");
                string fin = DateTime.Parse(txtFechaFin_TPV.Text).ToString("yyyy/MM/dd");
                divProductosVendidos.Visible = true;
                lblProductosVendidos.Text = $"{negDetalle.getTotaProductosVendidos(inicio, fin)}";
            }
        }
    }
}