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
    public class NegocioMarca
    {
        DAOMarca dao = new DAOMarca();

        public NegocioMarca() { }

        public DataTable getMarcas()
        {
            return dao.getMarcas();
        }

        public DataTable getMarcasActivas()
        {
            return dao.getMarcasActivas();
        }

        public DataTable getMarca(Marca marca)
        {
            return dao.getMarca(marca);
        }

        public bool setMarca(Marca marca)
        {
            return dao.setMarca(marca);
        }

        public bool updateMarca(Marca marca)
        {
            return dao.updateMarca(marca);
        }

        public bool deleteMarca(Marca marca)
        {
            return dao.deleteMarca(marca);
        }

        public DataTable getMaxId()
        {
            return dao.getMaxId();
        }
    }
}
