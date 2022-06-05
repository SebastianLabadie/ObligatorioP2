using System;
namespace Dominio
{
    public class TipoVehiculo : IValidacion
    {
        public static int UltimoId;
        public int Id { get; set; }
        public string Nombre { get; set; }

       

        public TipoVehiculo(string pNombre)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Nombre = pNombre;
        }

        public bool EsValido()
        {
            if (Nombre != "")
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
