using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        int id;
        Categoria categoria = new Categoria();
        Marca marca = new Marca();
        string nombre;
        string descripcion;
        decimal precio;
        int stock;
        string imagen;
        bool estado;

        public Producto() { }
        public Producto(int id) 
        {
            Id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public bool Estado { get => estado; set => estado = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
        public Marca Marca { get => marca; set => marca = value; }

        public void llenar(DataTable tablaProducto)
        {
            Id = Convert.ToInt32(tablaProducto.Rows[0]["IdProducto_Pr"]);
            Nombre = tablaProducto.Rows[0]["Nombre_Pr"].ToString().Trim();
            Categoria.Id = Convert.ToInt32(tablaProducto.Rows[0]["IdCategoria_Pr"]);
            Marca.Id = Convert.ToInt32(tablaProducto.Rows[0]["IdMarca_Pr"]);
            Descripcion = tablaProducto.Rows[0]["Descripcion_Pr"].ToString().Trim();
            Precio = Convert.ToDecimal(tablaProducto.Rows[0]["Precio_Pr"]);
            Stock = Convert.ToInt32(tablaProducto.Rows[0]["Stock_Pr"].ToString());
            Imagen = tablaProducto.Rows[0]["Imagen_Pr"].ToString().Trim();
            Estado = Convert.ToBoolean(tablaProducto.Rows[0]["Estado_Pr"]);
        }

        public string toString()
        {
            return $"{Id}, {Categoria.Id}, {Marca.Id}, {Nombre}, {Descripcion}, {Precio}, {Stock}, {Imagen}, {Estado}";
        }
    }
}
