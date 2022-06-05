using System;
namespace Dominio
{
    public class Plato:IValidacion //Herencia desde la clase Validacion
    {

        //Propiedades de la clase
        public static int UltimoId;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public static double precioMinimo;

        
        //Constructor
        public Plato(string pNombre,int pPrecio)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = pNombre;
            this.Precio = pPrecio;
        }

        //Procedimiento para traer datos del objeto
        public override string ToString()
        {
            return "Id: " + Id.ToString() + " Nombre: " + Nombre + " Precio: " + Precio.ToString();
        }

        public bool EsValido()
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
