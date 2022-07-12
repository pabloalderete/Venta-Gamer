using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public class DAOProducto
    {
        AccesoDatos ad = new AccesoDatos();
        public DAOProducto() { }

        public DataTable getProductos()
        {
            string q = $"SELECT * FROM Productos";

            return ad.obtenerTabla("Productos", q);
        }

        public DataTable getProductosPorCategoria(Categoria categoria)
        {
            string q = $"SELECT * FROM Productos INNER JOIN Categorias ON IdCategoria_Pr = IdCategoria_Ca WHERE IdCategoria_Pr = {categoria.Id}";

            return ad.obtenerTabla("ProductosPorCategoria", q);
        }

        public DataTable getProductosPorMarca(Marca marca)
        {
            string q = $"SELECT * FROM Productos INNER JOIN Marcas ON IdMarca_Pr = IdMarca_Ma WHERE IdMarca_Pr = {marca.Id}";

            return ad.obtenerTabla("MarcasPorCategoria", q);
        }

        public DataTable getProductosActivos()
        {
            string q = $"SELECT * FROM Productos INNER JOIN Categorias ON IdCategoria_Pr = IdCategoria_Ca INNER JOIN Marcas ON IdMarca_Pr = IdMarca_Ma WHERE Estado_Pr = 1 AND Estado_Ca = 1 AND Estado_Ma = 1";

            return ad.obtenerTabla("ProductosActivos", q);
        }

        public DataTable getProducto(Producto producto)
        {
            string q = $"SELECT * FROM Productos WHERE IdProducto_Pr = {producto.Id}";

            return ad.obtenerTabla("Producto", q);
        }

        public bool setProducto(Producto producto)
        {
            string q = "";
            if (producto.Imagen != null)
            {
                q = $"IF NOT EXISTS(SELECT * FROM Productos WHERE Nombre_Pr = '{producto.Nombre}') INSERT INTO Productos(IdCategoria_Pr, IdMarca_Pr, Nombre_Pr, Descripcion_Pr, Precio_Pr, Stock_Pr, Imagen_Pr, Estado_Pr) VALUES('{producto.Categoria.Id}', '{producto.Marca.Id}', '{producto.Nombre}', '{producto.Descripcion}', '{producto.Precio}', '{producto.Stock}', '{producto.Imagen}', '{producto.Estado}')";
            }
            else
            {
                q = $"IF NOT EXISTS(SELECT * FROM Productos WHERE Nombre_Pr = '{producto.Nombre}') INSERT INTO Productos(IdCategoria_Pr, IdMarca_Pr, Nombre_Pr, Descripcion_Pr, Precio_Pr, Stock_Pr, Estado_Pr) VALUES('{producto.Categoria.Id}', '{producto.Marca.Id}', '{producto.Nombre}', '{producto.Descripcion}', '{producto.Precio}', '{producto.Stock}', '{producto.Estado}')";
            }

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool updateProducto(Producto producto)
        {
            string precio = producto.Precio.ToString().Replace(',', '.');

            string q = $"UPDATE Productos SET IdCategoria_Pr = {producto.Categoria.Id}, IdMarca_Pr = {producto.Marca.Id}, Nombre_Pr = '{producto.Nombre}', Descripcion_Pr = '{producto.Descripcion}', Precio_Pr = CAST({precio} AS DECIMAL(8, 2)), Stock_Pr = {producto.Stock}, Imagen_Pr = '{producto.Imagen}', Estado_Pr = '{producto.Estado}' WHERE IdProducto_Pr = {producto.Id}";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool deleteProducto(Producto producto)
        {
            string q = $"UPDATE Productos SET Estado_Pr = 0 WHERE IdProducto_Pr = '{producto.Id}'";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public DataTable getMaxId()
        {
            string q = "SELECT MAX(IdProducto_Pr) AS Maximo FROM Productos";
            return ad.obtenerTabla("ProductosMaxId", q);
        }

        public DataTable getProductosBuscador(string q)
        {
            System.Diagnostics.Debug.WriteLine(q);

            string query = $"SELECT IdProducto_Pr, IdCategoria_Pr, IdMarca_Pr, Nombre_Pr, Descripcion_Pr, Precio_Pr, Stock_Pr,  Imagen_Pr, Estado_Pr FROM Productos JOIN Categorias ON IdCategoria_Pr = IdCategoria_Ca JOIN Marcas ON IdMarca_Pr = IdMarca_Ma WHERE Nombre_Pr LIKE  '%' + RTRIM('{q}') + '%' OR Nombre_Ma LIKE '%' + RTRIM('{q}') + '%' OR Nombre_Ca LIKE '%' + RTRIM('{q}') + '%' OR Descripcion_Pr LIKE '%' + RTRIM('{q}') + '%'";

            return ad.obtenerTabla("ProductosBuscador", query);
        }
    }
}
