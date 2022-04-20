using System;
namespace ObligatorioP2
{
    public class Plato:IValidacion
    {
        public static int UltimoId;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public static double precioMinimo;

        

        public Plato(string pNombre,int pPrecio)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = pNombre;
            this.Precio = pPrecio;
        }

        public override string ToString()
        {
            return "Id: " + Id.ToString() + " Nombre: " + Nombre + " Precio: " + Precio.ToString();
        }

        public bool esValido()
        {
            if (Nombre != "" && Precio > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
