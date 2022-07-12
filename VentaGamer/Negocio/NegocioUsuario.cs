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
    public class NegocioUsuario
    {
        DAOUsuario dao = new DAOUsuario();
        public NegocioUsuario() { }

        public DataTable getLogin(Usuario usuario)
        {
            return dao.getLogin(usuario);
        }

        public DataTable getUsuarios()
        {
            return dao.getUsuarios();
        }

        public DataTable getUsuario(Usuario usuario)
        {
            return dao.getUsuario(usuario);
        }

        public bool setRegistro(Usuario usuario)
        {
            return dao.setRegistro(usuario);
        }

        public bool updateUsuario(Usuario usuario)
        {
            return dao.updateUsuario(usuario);
        }

        public bool exists(Usuario usuario)
        {
            return dao.exists(usuario);
        }

        public bool ifValid(Usuario usuario)
        {
            return dao.ifValid(usuario);
        }
    }
}
