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
    public partial class DetalleDeFactura : System.Web.UI.Page
    {
        NegocioDetalleFactura negDF = new NegocioDetalleFactura();
        NegocioFactura negFactura = new NegocioFactura();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idFactura = Convert.ToInt32(Request.Params["IdFactura"]);
            Factura factura = new Factura(idFactura);

            if(negFactura.exists(factura) && Session["Usuario"] != null)
            {
                int dniUsuario = Convert.ToInt32(((DataTable)Session["Usuario"]).Rows[0]["Dni_Us"]);
                DataTable tablaFactura = negFactura.getFactura(factura);
                int dniFactura = Convert.ToInt32(tablaFactura.Rows[0]["Dni_Fa"]);
                if (dniUsuario == dniFactura)
                {
                    lblNumeroFactura.Text = $"Detalle de Factura N° {Request.Params["IdFactura"]}";
                    DetalleFactura detalleFactura = new DetalleFactura(idFactura);
                    rptDetalleFactura.DataSource = negDF.getDetalleDeFacturaProductos(detalleFactura);
                    rptDetalleFactura.DataBind();
                }
                else
                {
                    lblNumeroFactura.Text = "No tiene permiso para ver esto";
                    rptDetalleFactura.Visible = false;
                }
            }
            else
            {
                lblNumeroFactura.Text = "Ocurrio un error";
                rptDetalleFactura.Visible = false;
            }

                        
        }

        protected void lnkFinalizarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
    }
}