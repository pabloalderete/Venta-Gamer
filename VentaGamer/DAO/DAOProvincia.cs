using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public class DAOProvincia
    {
        AccesoDatos ad = new AccesoDatos();
        public DAOProvincia() { }

        public DataTable getProvincias()
        {
            string q = "SELECT * FROM Provincias";

            return ad.obtenerTabla("Provincias", q);
        }
    }
}
