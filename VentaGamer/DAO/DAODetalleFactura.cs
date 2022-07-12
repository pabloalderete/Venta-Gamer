using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public class DAODetalleFactura
    {
        AccesoDatos ad = new AccesoDatos();

        public DAODetalleFactura() { }

        public DataTable getDetalleDeFacturas()
        {
            string q = $"SELECT * FROM DetalleFacturas";

            return ad.obtenerTabla("DetalleDeFacturas", q);
        }

        public DataTable getDetalleDeFactura(DetalleFactura detalleFactura)
        {
            string q = $"SELECT * FROM DetalleFacturas WHERE IdFactura_DF = {detalleFactura.Factura.Id}";

            return ad.obtenerTabla("DetalleDeFactura", q);
        }

        public DataTable getDetalleDeFacturaProductos(DetalleFactura detalleFactura)
        {
            string q = $"SELECT * FROM DetalleFacturas JOIN Productos ON IdProducto_PR = IdProducto_DF WHERE IdFactura_DF = {detalleFactura.Factura.Id}";

            return ad.obtenerTabla("DetalleDeFacturaProductos", q);
        }

        public DataTable getTotaProductosVendidos(string inicio, string fin)
        {
            string q = $"SELECT SUM(Cantidad_DF) AS TotalProductosVendidos FROM DetalleFacturas INNER JOIN Facturas ON IdFactura_DF = IdFactura_Fa WHERE Fecha_Fa BETWEEN '{inicio} 00:00:00' AND '{fin} 23:59:59'";

            return ad.obtenerTabla("TotaProductosVendidos", q);
        }

        public bool setDetalleDeFactura(DetalleFactura detalleFactura)
        {
            string q = $"INSERT INTO DetalleFacturas VALUES('{detalleFactura.Producto.Id}', '{detalleFactura.Factura.Id}', '{detalleFactura.Cantidad}', '{detalleFactura.PrecioUnitario}')";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }
    }
}
