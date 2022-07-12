using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public class DAOMarca
    {
        AccesoDatos ad = new AccesoDatos();
        public DAOMarca() { }

        public DataTable getMarcas()
        {
            string q = $"SELECT * FROM Marcas";

            return ad.obtenerTabla("Marcas", q);
        }

        public DataTable getMarcasActivas()
        {
            string q = $"SELECT * FROM Marcas WHERE Estado_Ma = 1";

            return ad.obtenerTabla("MarcasActivas", q);
        }

        public DataTable getMarca(Marca marca)
        {
            string q = $"SELECT * FROM Marcas WHERE IdMarca_Ma = {marca.Id}";

            return ad.obtenerTabla("Marca", q);
        }

        public bool setMarca(Marca marca)
        {
            string q = $"IF NOT EXISTS(SELECT * FROM Marcas WHERE Nombre_Ma = '{marca.Nombre}') INSERT INTO Marcas(Nombre_Ma, Eslogan_Ma, Imagen_Ma, Estado_Ma) VALUES('{marca.Nombre}', '{marca.Eslogan}', '{marca.Imagen}', '{marca.Estado}')";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool updateMarca(Marca marca)
        {
            string q = $"UPDATE Marcas SET Nombre_Ma = '{marca.Nombre}', Eslogan_Ma = '{marca.Eslogan}', Imagen_Ma = '{marca.Imagen}', Estado_Ma = '{marca.Estado}' WHERE IdMarca_Ma = '{marca.Id}'";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public bool deleteMarca(Marca marca)
        {
            string q = $"UPDATE Marcas SET Estado_Ma = 0 WHERE IdMarca_Ma = '{marca.Id}'";

            if (ad.ejecutarTransaccion(q) == 1)
            {
                return true;
            }

            return false;
        }

        public DataTable getMaxId()
        {
            string q = "SELECT MAX(IdMarca_Ma) AS Maximo FROM Marcas";

            return ad.obtenerTabla("MarcasMaxId", q);
        }
    }
}
