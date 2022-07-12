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
    public class NegocioCategoria
    {
        DAOCategoria dao = new DAOCategoria();

        public NegocioCategoria() { }

        public DataTable getCategorias()
        {
            return dao.getCategorias();
        }

        public DataTable getCategoriasActivas()
        {
            return dao.getCategoriasActivas();
        }

        public DataTable getCategoria(Categoria categoria)
        {
            return dao.getCategoria(categoria);
        }

        public bool setCategoria(Categoria categoria)
        {
            return dao.setCategoria(categoria);
        }

        public bool deleteCategoria(Categoria categoria)
        {
            return dao.deleteCategoria(categoria);
        }

        public bool updateCategoria(Categoria categoria)
        {
            return dao.updateCategoria(categoria);
        }

        public DataTable getMaxId()
        {
            return dao.getMaxId();
        }
    }
}
