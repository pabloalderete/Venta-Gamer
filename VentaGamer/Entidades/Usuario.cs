using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        string dni;
        Provincia provincia = new Provincia();
        Localidad localidad = new Localidad();
        string nombre;
        string apellido;
        string email;
        string contrasena;
        string direccion;
        string telefono;
        string imagen;
        bool permiso;
        bool estado;

        public Usuario() { }

        public string Dni { get => dni; set => dni = value; }
        public Provincia Provincia { get => provincia; set => provincia = value; }
        public Localidad Localidad { get => localidad; set => localidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public bool Permiso { get => permiso; set => permiso = value; }
        public bool Estado { get => estado; set => estado = value; }

        public void llenar(DataTable tablaUsuario)
        {
            Dni = tablaUsuario.Rows[0]["Dni_Us"].ToString();
            Provincia.Id = Convert.ToInt32(tablaUsuario.Rows[0]["IdProvincia_Us"]);
            Localidad.Id = Convert.ToInt32(tablaUsuario.Rows[0]["IdLocalidad_Us"]);
            Nombre = tablaUsuario.Rows[0]["Nombre_Us"].ToString();
            Apellido = tablaUsuario.Rows[0]["Apellido_Us"].ToString();
            Email = tablaUsuario.Rows[0]["Email_Us"].ToString();
            Contrasena = tablaUsuario.Rows[0]["Contrasena_Us"].ToString();
            Direccion = tablaUsuario.Rows[0]["Direccion_Us"].ToString();
            Telefono = tablaUsuario.Rows[0]["Telefono_Us"].ToString();
            Imagen = tablaUsuario.Rows[0]["ImagenPerfil_Us"].ToString();
            Permiso = Convert.ToBoolean(tablaUsuario.Rows[0]["Permiso_Us"]);
            Estado = Convert.ToBoolean(tablaUsuario.Rows[0]["Permiso_Us"]);
        }
    }
}
