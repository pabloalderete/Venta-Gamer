using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        int id;
        TiposPago tiposPago = new TiposPago();
        Usuario usuario = new Usuario();
        bool envio;
        string direccion;
        string rangoHorario;
        decimal montoFinal;
        DateTime fecha;
        int estado;

        public Factura() { }

        public Factura(int id)
        {
            Id = id;
        }

        public int Id { get => id; set => id = value; }
        public TiposPago TiposPagos { get => tiposPago; set => tiposPago = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public bool Envio { get => envio; set => envio = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string RangoHorario { get => rangoHorario; set => rangoHorario = value; }
        public decimal MontoFinal { get => montoFinal; set => montoFinal = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
