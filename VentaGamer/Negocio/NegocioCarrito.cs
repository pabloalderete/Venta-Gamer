using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAO;
using System.Data;

namespace Negocio
{
    public class NegocioCarrito
    {
        public NegocioCarrito() { }

        public DataTable crearTabla()
        {
            DataTable dt = new DataTable("Carrito");
            DataColumn dc = new DataColumn("IdProducto", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("IdCategoria", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("IdMarca", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Nombre", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Descripcion", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Precio", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Stock", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Imagen", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Estado", Type.GetType("System.Boolean"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Cantidad", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Total", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);

            return dt;
        }

        public void agregarFila(DataTable dt, Producto producto)
        {
            DataRow dr = dt.NewRow();
            dr["IdProducto"] = producto.Id;
            dr["IdCategoria"] = producto.Categoria.Id;
            dr["IdMarca"] = producto.Marca.Id;
            dr["Nombre"] = producto.Nombre;
            dr["Descripcion"] = producto.Descripcion;
            dr["Precio"] = producto.Precio;
            dr["Stock"] = producto.Stock;
            dr["Imagen"] = producto.Imagen;
            dr["Estado"] = producto.Estado;
            dr["Cantidad"] = 1;
            dr["Total"] = 0;

            dt.Rows.Add(dr);
        }

        public void eliminarFila(DataTable dt, int index)
        {
            dt.Rows[index].Delete();
        }

        public bool estaRepetido(DataTable dt, int id)
        {
            bool repetido = false;

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == id)
                {
                    repetido = true;
                }
            }

            return repetido;
        }
    }
}
