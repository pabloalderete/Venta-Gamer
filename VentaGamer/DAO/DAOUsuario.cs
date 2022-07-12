using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOUsuario
    {
        AccesoDatos ad = new AccesoDatos();

        public DAOUsuario() { }

        public DataTable getLogin(Usuario usuario)
        {
            string q = $"SELECT * FROM Usuarios WHERE Email_Us = '{usuario.Email}' AND Contrasena_Us = '{usuario.Contrasena}'";

            return ad.obtenerTabla("UsuarioLogin", q);
        }

        public DataTable getUsuarios()
        {
            string q = "SELECT * FROM Usuarios";

            return ad.obtenerTabla("Usuarios", q);
        }

        public DataTable getUsuario(Usuario usuario)
        {
            string q = $"SELECT * FROM Usuarios WHERE Dni_Us = '{usuario.Dni}'";

            return ad.obtenerTabla("Usuario", q);
        }

        private void armarParametrosAlta(ref SqlCommand comando, Usuario usuario)
        {
            SqlParameter parametros = comando.Parameters.Add("@Dni", SqlDbType.Char, 8);
            parametros.Value = usuario.Dni;
            parametros = comando.Parameters.Add("@IdProvincia", SqlDbType.Int);
            parametros.Value = usuario.Provincia.Id;
            parametros = comando.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            parametros.Value = usuario.Localidad.Id;
            parametros = comando.Parameters.Add("@Nombre", SqlDbType.NChar, 20);
            parametros.Value = usuario.Nombre;
            parametros = comando.Parameters.Add("@Apellido", SqlDbType.NChar, 20);
            parametros.Value = usuario.Apellido;
            parametros = comando.Parameters.Add("@Email", SqlDbType.NChar, 50);
            parametros.Value = usuario.Email;
            parametros = comando.Parameters.Add("@Contrasena", SqlDbType.NChar, 20);
            parametros.Value = usuario.Contrasena;
            parametros = comando.Parameters.Add("@Direccion", SqlDbType.NChar, 50);
            parametros.Value = usuario.Direccion;
            parametros = comando.Parameters.Add("@Telefono", SqlDbType.NChar, 10);
            parametros.Value = usuario.Telefono;
        }

        public bool setRegistro(Usuario usuario)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosAlta(ref comando, usuario);

            if (ad.ejecutarProcedimientoAlmacenado(comando, "SP_ALTA_USUARIOS") == 1)
            {
                return true;
            }

            return false;
        }

        public bool updateUsuario(Usuario usuario)
        {
            string q = "";

            if (usuario.Imagen != null)
            {
                q = $"UPDATE Usuarios SET IdProvincia_Us = '{usuario.Provincia.Id}', IdLocalidad_Us = '{usuario.Localidad.Id}', Nombre_Us = '{usuario.Nombre}', Apellido_Us = '{usuario.Apellido}', Contrasena_Us = '{usuario.Contrasena}', Direccion_Us = '{usuario.Direccion}', Telefono_Us = '{usuario.Telefono}', ImagenPerfil_Us = '{usuario.Imagen}' WHERE Dni_Us = '{usuario.Dni}'";
            }
            else
            {
                q = $"UPDATE Usuarios SET IdProvincia_Us = '{usuario.Provincia.Id}', IdLocalidad_Us = '{usuario.Localidad.Id}', Nombre_Us = '{usuario.Nombre}', Apellido_Us = '{usuario.Apellido}', Contrasena_Us = '{usuario.Contrasena}', Direccion_Us = '{usuario.Direccion}', Telefono_Us = '{usuario.Telefono}' WHERE Dni_Us = '{usuario.Dni}'";
            }


            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool exists(Usuario usuario)
        {
            string q = $"SELECT Email_Us, Contrasena_Us FROM Usuarios WHERE Email_Us = '{usuario.Email}' AND Contrasena_Us = '{usuario.Contrasena}'";

            if (ad.obtenerTabla("UsuarioExists", q).Rows.Count != 0)
            {
                return true;
            }

            return false;
        }

        public bool ifValid(Usuario usuario)
        {
            string q = $"SELECT Email_Us, Contrasena_Us, Estado_Us FROM Usuarios WHERE Email_Us = '{usuario.Email}' AND Contrasena_Us = '{usuario.Contrasena}' AND Estado_Us = 1";

            if (ad.obtenerTabla("UsuarioValid", q).Rows.Count != 0)
            {
                return true;
            }

            return false;
        }
    }
}
