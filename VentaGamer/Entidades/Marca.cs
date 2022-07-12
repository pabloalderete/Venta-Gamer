using System;
using System.Data;

namespace Entidades
{
    public class Marca
    {
        int id;
        string nombre;
        string eslogan;
        string imagen;
        bool estado;

        public Marca() { }
        public Marca(int id)
        {
            Id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Eslogan { get => eslogan; set => eslogan = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public bool Estado { get => estado; set => estado = value; }

        public void llenar(DataTable tablaMarca)
        {
            Id = Convert.ToInt32(tablaMarca.Rows[0]["IdMarca_Ma"]);
            Nombre = tablaMarca.Rows[0]["Nombre_Ma"].ToString().Trim();
            Eslogan = tablaMarca.Rows[0]["Eslogan_Ma"].ToString().Trim();
            Imagen = tablaMarca.Rows[0]["Imagen_Ma"].ToString().Trim();
            Estado = Convert.ToBoolean(tablaMarca.Rows[0]["Estado_Ma"]);
        }

        public string toString()
        {
            return $"{Id}, {Nombre},{Eslogan}, {Imagen}, {Estado}";
        }
    }
}