using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public class DAOLocalidad
    {
        AccesoDatos ad = new AccesoDatos();
        public DAOLocalidad() { }

        public DataTable getLocalidades()
        {
            string q = "SELECT * FROM Localidades";

            return ad.obtenerTabla("Localidades", q);
        }

        public DataTable getLocalidadProvincias(Localidad localidad)
        {
            string q = $"SELECT * FROM Localidades INNER JOIN Provincias ON IdProvincia_Lo = IdProvincia_Prv WHERE IdProvincia_Lo = {localidad.Provincia.Id}";

            return ad.obtenerTabla("LocalidadProvincias", q);
        }
    }
}
