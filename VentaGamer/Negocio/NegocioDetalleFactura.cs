using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;

namespace Negocio
{
    public class NegocioDetalleFactura
    {
        DAODetalleFactura dao = new DAODetalleFactura();
        public NegocioDetalleFactura() { }

        public DataTable getDetalleDeFacturas()
        {
            return dao.getDetalleDeFacturas();
        }

        public DataTable getDetalleDeFactura(DetalleFactura detalleFactura)
        {
            return dao.getDetalleDeFactura(detalleFactura);
        }

        public DataTable getDetalleDeFacturaProductos(DetalleFactura detalleFactura)
        {
            return dao.getDetalleDeFacturaProductos(detalleFactura);
        }

        public int getTotaProductosVendidos(string inicio, string fin)
        {
            DataTable dt = dao.getTotaProductosVendidos(inicio, fin);
            int cantidad = 0;

            if (dt.Rows[0]["TotalProductosVendidos"] != DBNull.Value)
            {
                cantidad = Convert.ToInt32(dt.Rows[0]["TotalProductosVendidos"]);
            }

            return cantidad;
        }
        public bool setDetalleDeFactura(DetalleFactura detalleFactura)
        {
            return dao.setDetalleDeFactura(detalleFactura);
        }

        public decimal getMontoFinal(DetalleFactura detalleFactura)
        {
            DataTable dt = dao.getDetalleDeFactura(detalleFactura);
            decimal total = 0;

            foreach(DataRow dr in dt.Rows)
            {
                total += Convert.ToDecimal(dr["PrecioUnitario_DF"]) * Convert.ToDecimal(dr["Cantidad_DF"]);
            }

            return total;
        }
    }
}
