using System;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public class Plato:IValidacion,IComparable<Plato> //Herencia desde la clase Validacion
    {

        //Propiedades de la clase
        public static int UltimoId;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Likes { get; set; }

        public static double precioMinimo;


        
        //Constructor
        public Plato(string pNombre,int pPrecio)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = pNombre;
            this.Precio = pPrecio;
            this.Likes = 0;
        }

        //Funcion Comparte para poder Ordenar la lista por Precio y Nombre
        public int CompareTo([AllowNull] Plato other)
        {
            if (Nombre.CompareTo(other.Nombre) > 0)
            {
                return 1;
            }
            if (Nombre.CompareTo(other.Nombre) < 0)
            {
                return -1;

            }

           return 0;
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
