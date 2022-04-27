using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace ObligatorioP2
{
    public abstract class Persona : IComparable<Persona>,IValidacion
    {
        public static int UltimoId;

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public Persona(string pNombre, string pApellido)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
        }

       

        public static bool ValidarNombre()
        {
            return true;
        }

        public static bool ValidarApellido()
        {
            return true;
        }

        public override string ToString()
        {
            return "Id: " + this.Id.ToString() + " Nombre: " + this.Nombre + " Apellido: " + this.Apellido;
        }


    

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

        public abstract bool EsValido();
    
    }
}
