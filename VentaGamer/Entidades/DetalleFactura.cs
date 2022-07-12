using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFactura
    {
        Producto producto = new Producto();
        Factura factura = new Factura();
        int cantidad;
        float precioUnitario;

        public DetalleFactura() { }
        public DetalleFactura(int idFactura) {
            factura.Id = idFactura;
        }

        public Producto Producto { get => producto; set => producto = value; }
        public Factura Factura { get => factura; set => factura = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
    }
}
