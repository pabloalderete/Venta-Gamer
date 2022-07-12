using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        int id;
        Provincia provincia = new Provincia();
        string nombre;
        string codPostal;

        public Localidad() { }

        public int Id { get => id; set => id = value; }
        public Provincia Provincia { get => provincia; set => provincia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string CodPostal { get => codPostal; set => codPostal = value; }
    }
}
