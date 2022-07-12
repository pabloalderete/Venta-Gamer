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
    public partial class SeleccionarEnvioTipoPago : System.Web.UI.Page
    {
        NegocioDetalleFactura negDetalleFactura = new NegocioDetalleFactura();
        NegocioFactura negFacturas = new NegocioFactura();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                chkSucursal.Checked = true;
                chkContado.Checked = true;
            }
        }

        protected void lnkFinalizarCompra_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura();
            
            if (chkContado.Checked)
            {
                factura.TiposPagos.Cod = "CON";
                factura.Estado = 2;

            }
            else
            {
                factura.TiposPagos.Cod = "TAR";
                factura.Estado = 1;
            }

            factura.Usuario.Dni = ((DataTable)Session["Usuario"]).Rows[0]["Dni_Us"].ToString().Trim();
            factura.Envio = Convert.ToBoolean(chkDomicilio.Checked);
            factura.Direccion = ((DataTable)Session["Usuario"]).Rows[0]["Direccion_Us"].ToString().Trim();
            factura.RangoHorario = "09:00-18:00";
            factura.MontoFinal = 0;
            negFacturas.setFactura(factura);
            factura.Id = getMaxIdFacturas();
            DetalleFactura detalleFactura = new DetalleFactura(factura.Id);

            for (int i = 0; i < ((DataTable)Session["Carrito"]).Rows.Count; i++)
            {
                detalleFactura.Producto.Id = Convert.ToInt32(((DataTable)Session["Carrito"]).Rows[i]["IdProducto"]);
                detalleFactura.Cantidad = Convert.ToInt32(((DataTable)Session["Carrito"]).Rows[i]["Cantidad"]);
                detalleFactura.PrecioUnitario = Convert.ToInt32(((DataTable)Session["Carrito"]).Rows[i]["Precio"]);
                negDetalleFactura.setDetalleDeFactura(detalleFactura);
            }

            factura.MontoFinal = negDetalleFactura.getMontoFinal(detalleFactura);
            negFacturas.updateFactura(factura);

            if (Session["Carrito"] != null)
            {
                Session["Carrito"] = null;
            }

            Response.Redirect($"~/DetalleDeFactura.aspx?IdFactura={factura.Id}");
        }

        private int getMaxIdFacturas()
        {
            DataTable dt = negFacturas.getMaxID();
            int maxId = Convert.ToInt32(dt.Rows[0]["MaximoId"]);

            return maxId;
        }
    }
}