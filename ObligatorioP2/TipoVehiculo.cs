using System;
namespace ObligatorioP2
{
    public class TipoVehiculo
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
    }
}
