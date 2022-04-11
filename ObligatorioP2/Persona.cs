using System;
namespace ObligatorioP2
{
    public abstract class Persona
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


    }
}
