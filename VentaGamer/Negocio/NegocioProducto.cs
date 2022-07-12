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
    public class NegocioProducto
    {
        DAOProducto dao = new DAOProducto();
        public DataTable getProductos()
        {
            return dao.getProductos();
        }

        public DataTable getProductosPorCategoria(Categoria categoria)
        {
            return dao.getProductosPorCategoria(categoria);
        }

        public DataTable getProductosPorMarca(Marca marca)
        {
            return dao.getProductosPorMarca(marca);
        }

        public DataTable getProductosActivos()
        {
            return dao.getProductosActivos();
        }

        public DataTable getProducto(Producto producto)
        {
            return dao.getProducto(producto);
        }

        public bool setProducto(Producto producto)
        {
            return dao.setProducto(producto);
        }

        public bool updateProducto(Producto producto)
        {
            return dao.updateProducto(producto);
        }

        public bool deleteProducto(Producto producto)
        {
            return dao.deleteProducto(producto);
        }

        public DataTable getMaxId()
        {
            return dao.getMaxId();
        }

        public DataTable getProductosBuscador(string q)
        {
            return dao.getProductosBuscador(q);
        }
    }
}
