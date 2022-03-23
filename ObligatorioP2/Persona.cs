using System;
namespace ObligatorioP2
{
    public class Persona
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public Persona(int pId, string pNombre, string pApellido)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.apellido = pApellido;
        }

        public Persona()
        {

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
