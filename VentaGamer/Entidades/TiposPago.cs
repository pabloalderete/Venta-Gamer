namespace Entidades
{
    public class TiposPago
    {
        string cod;
        string descripcion;

        public TiposPago() { }

        public string Cod { get => cod; set => cod = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}