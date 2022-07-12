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
    public class NegocioProvincia
    {
        DAOProvincia dao = new DAOProvincia();
        public NegocioProvincia() { }

        public DataTable getProvincias()
        {
            return dao.getProvincias();
        }
    }
}
