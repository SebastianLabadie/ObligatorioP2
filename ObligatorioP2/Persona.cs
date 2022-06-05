using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Dominio
{
    public abstract class Persona : IComparable<Persona>,IValidacion //Herencia de IComparable para de esta forma poder ordenar las listas y de iValidacion para poder tener la funcion de validar
    {

        //Se define variable estatica de la clase
        public static int UltimoId;


        //Se crean Atributos de la clase
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }


        //Constructor
        public Persona(string pNombre, string pApellido)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
        }


        //Funcion para devolver datos del objeto
        public override string ToString()
        {
            return "Id: " + this.Id.ToString() + " Nombre: " + this.Nombre + " Apellido: " + this.Apellido;
        }


    
        //Funcion Comparte para poder Ordenar la lista por Apellido y Nombre
        public int CompareTo([AllowNull] Persona other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return 1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;

            }
            else
            {
                if (Nombre.CompareTo(other.Nombre) > 0)

                {
                    return 1;
                }

                else if (Nombre.CompareTo(other.Nombre) < 0)
                {
                    return -1;
                }

                else
                {
                    return 0;
                }
            }
        }

        public abstract bool EsValido();//Funcion Abstracta para poder utilizarla en las clases hijas
    
    }
}
