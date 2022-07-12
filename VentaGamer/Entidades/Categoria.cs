using System;
using System.Data;

namespace Entidades
{
    public class Categoria
    {
        int id;
        string nombre;
        string descripcion;
        string imagen;
        bool estado;

        public Categoria() { }
        public Categoria(int id) {
            Id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public bool Estado { get => estado; set => estado = value; }

        public void llenar(DataTable tablaCategoria)
        {
            Id = Convert.ToInt32(tablaCategoria.Rows[0]["IdCategoria_Ca"]);
            Nombre = tablaCategoria.Rows[0]["Nombre_Ca"].ToString().Trim();
            Descripcion = tablaCategoria.Rows[0]["Descripcion_Ca"].ToString().Trim();
            Imagen = tablaCategoria.Rows[0]["Imagen_Ca"].ToString().Trim();
            Estado = Convert.ToBoolean(tablaCategoria.Rows[0]["Estado_Ca"]);
        }

        public string toString()
        {
            return $"{Id}, {Nombre}, {Descripcion}, {Imagen}, {Estado}";
        }
    }
}