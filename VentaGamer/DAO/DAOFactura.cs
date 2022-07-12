using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public class DAOFactura
    {
        AccesoDatos ad = new AccesoDatos();

        public DAOFactura() { }

        public DataTable getFacturas()
        {
            string q = $"SELECT * FROM Facturas";

            return ad.obtenerTabla("Facturas", q);
        }

        public DataTable getFactura(Factura factura)
        {
            string q = $"SELECT * FROM Facturas WHERE IdFactura_Fa = {factura.Id}";

            return ad.obtenerTabla("Factura", q);
        }

        public DataTable getFacturasUsuarios()
        {
            string q = "SELECT * FROM Facturas INNER JOIN Usuarios ON Dni_Fa = Dni_Us";

            return ad.obtenerTabla("FacturasUsuarios", q);
        }

        public DataTable getFacturasUsuariosTiposPago()
        {
            string q = "SELECT * FROM Facturas INNER JOIN Usuarios ON Dni_Fa = Dni_Us INNER JOIN TiposPago ON CodTipoPago_Fa = CodTipoPago_TP";

            return ad.obtenerTabla("FacturasUsuariosTiposPago", q);
        }

        public DataTable getFacturasBetween(string inicio, string fin)
        {
            string q = $"SELECT MontoFinal_Fa FROM Facturas WHERE Fecha_Fa BETWEEN '{inicio} 00:00:00' AND '{fin} 23:59:59.999'";

            return ad.obtenerTabla("FacturasBetween", q);
        }

        public bool updateFactura(Factura factura)
        {
            string montoFinal = factura.MontoFinal.ToString().Replace(',', '.');
            string q = $"UPDATE Facturas SET CodTipoPago_Fa = '{factura.TiposPagos.Cod}', Dni_Fa = '{factura.Usuario.Dni}', Envio_Fa = '{factura.Envio}', Direccion_Fa = '{factura.Usuario.Direccion}', RangoHorario_Fa = '{factura.RangoHorario}', MontoFinal_Fa = CAST({montoFinal} AS DECIMAL(8, 2)), Fecha_Fa = GETDATE() WHERE IdFactura_Fa = {factura.Id}";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool setFactura(Factura factura)
        {
            //Estado 1 -> paga | 2 -> pendiente
            string q = $"INSERT INTO Facturas VALUES('{factura.TiposPagos.Cod}', '{factura.Usuario.Dni}', '{factura.Envio}', '{factura.Direccion}', '{factura.RangoHorario}', '{factura.MontoFinal}', GETDATE(), {factura.Estado})";
            
            if(factura.Estado == 0)
            {
                q = $"INSERT INTO Facturas (CodTipoPago_Fa, Dni_Fa, Envio_Fa, Direccion_Fa, RangoHorario_Fa, MontoFinal_Fa, Fecha_Fa) VALUES('{factura.TiposPagos.Cod}', '{factura.Usuario.Dni}', '{factura.Envio}', '{factura.Direccion}', '{factura.RangoHorario}', '{factura.MontoFinal}', GETDATE())";
            }

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public DataTable exists(Factura factura)
        {
            string q = $"IF EXISTS (SELECT 1 FROM Facturas WHERE IdFactura_Fa = {factura.Id}) SELECT 1 AS Existe ELSE SELECt 0 AS Existe";

            return ad.obtenerTabla("ExistsFactura", q);
        }

        public DataTable getMaxID()
        {
            string q = $"IF NOT EXISTS (SELECT 1 FROM Facturas) SELECT 0 AS MaximoId ELSE SELECT MAX(IdFactura_Fa) AS MaximoId FROM Facturas";

            return ad.obtenerTabla("maxIdFacturas", q);
        }
    }
}
