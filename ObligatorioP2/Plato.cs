using System;
namespace ObligatorioP2
{
    public class Plato
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public static int precioMinimo;

        public Plato()
        {
            
        }

        public Plato(int pId,string pNombre,int pPrecio)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.precio = pPrecio;
        }

        public override string ToString()
        {
            return "id: " + id.ToString() + " nombre: " + nombre + " precio: " + precio.ToString();
        }

    }
}
