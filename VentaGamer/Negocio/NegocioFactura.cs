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
    public class NegocioFactura
    {
        DAOFactura dao = new DAOFactura();

        public NegocioFactura() { }

        public DataTable getFacturas()
        {
            return dao.getFacturas();
        }

        public DataTable getFactura(Factura factura)
        {
            return dao.getFactura(factura);
        }

        public DataTable getFacturasUsuarios()
        {
            return dao.getFacturasUsuarios();
        }

        public DataTable getFacturasUsuariosTiposPago()
        {
            return dao.getFacturasUsuariosTiposPago();
        }

        public decimal getMontoIngreso(string inicio, string fin)
        {
            decimal ingreso = 0;
            DataTable dt = dao.getFacturasBetween(inicio, fin);

            foreach(DataRow dr in dt.Rows)
            {
                ingreso += Convert.ToDecimal(dr["MontoFinal_Fa"]);
            }

            return ingreso;
        }

        public bool updateFactura(Factura factura)
        {
            return dao.updateFactura(factura);
        }

        public bool setFactura(Factura factura)
        {
            return dao.setFactura(factura);
        }

        public bool exists(Factura factura)
        {
            DataTable dt = dao.exists(factura);
            bool existe = Convert.ToBoolean(dt.Rows[0]["Existe"]);

            return existe;
        }
        public DataTable getMaxID()
        {
            return dao.getMaxID();
        }
    }
}
