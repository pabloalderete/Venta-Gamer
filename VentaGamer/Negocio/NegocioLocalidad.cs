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
    public class NegocioLocalidad
    {
        DAOLocalidad dao = new DAOLocalidad();
        public NegocioLocalidad() { }

        public DataTable getLocalidades()
        {
            return dao.getLocalidades();
        }

        public DataTable getLocalidadProvincias(Localidad localidad)
        {
            return dao.getLocalidadProvincias(localidad);
        }
    }
}
