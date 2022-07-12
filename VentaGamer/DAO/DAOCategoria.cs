using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOCategoria
    {
        AccesoDatos ad = new AccesoDatos();

        public DAOCategoria() { }

        public DataTable getCategorias()
        {
            string q = $"SELECT * FROM Categorias";

            return ad.obtenerTabla("Categorias", q);
        }

        public DataTable getCategoriasActivas()
        {
            string q = $"SELECT * FROM Categorias WHERE Estado_Ca = 1";

            return ad.obtenerTabla("CategoriasActivas", q);
        }

        public DataTable getCategoria(Categoria categoria)
        {
            string q = $"SELECT * FROM Categorias WHERE IdCategoria_Ca = {categoria.Id}";

            return ad.obtenerTabla("Producto", q);
        }

        public bool setCategoria(Categoria categoria)
        {
            string q = $"IF NOT EXISTS(SELECT * FROM Categorias WHERE Nombre_Ca = '{categoria.Nombre}') INSERT INTO Categorias(Nombre_Ca, Descripcion_Ca, Imagen_Ca, Estado_Ca) VALUES('{categoria.Nombre}', '{categoria.Descripcion}', '{categoria.Imagen}', '{categoria.Estado}')";

            if(ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool deleteCategoria(Categoria categoria)
        {
            string q = $"UPDATE Categorias SET Estado_Ca = 0 WHERE IdCategoria_Ca = '{categoria.Id}'";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool updateCategoria(Categoria categoria)
        {
            string q = $"UPDATE Categorias SET Nombre_Ca = '{categoria.Nombre}', Descripcion_Ca = '{categoria.Descripcion}', Imagen_Ca = '{categoria.Imagen}', Estado_Ca = '{categoria.Estado}' WHERE IdCategoria_Ca = '{categoria.Id}'";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public DataTable getMaxId()
        {
            string q = "SELECT MAX(IdCategoria_Ca) AS Maximo FROM Categorias";
            return ad.obtenerTabla("CategoriasMaxId", q);
        }
    }
}
