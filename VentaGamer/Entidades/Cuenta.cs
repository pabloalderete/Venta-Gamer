using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuenta
    {
        string CBU;
        Usuario usuario;
        float saldo;
        bool estado;

        public Cuenta() { }

        public string CBU1 { get => CBU; set => CBU = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public float Saldo { get => saldo; set => saldo = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
