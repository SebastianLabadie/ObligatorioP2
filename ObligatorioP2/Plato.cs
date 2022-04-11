using System;
namespace ObligatorioP2
{
    public class Plato
    {
        public static int UltimoId;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public static double precioMinimo;

        public Plato()
        {
            
        }

        public Plato(string pNombre,int pPrecio)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = pNombre;
            this.Precio = pPrecio;
        }

        public override string ToString()
        {
            return "id: " + Id.ToString() + " nombre: " + Nombre + " precio: " + Precio.ToString();
        }

    }
}
