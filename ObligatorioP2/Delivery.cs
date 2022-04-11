using System;
namespace ObligatorioP2
{
    public class Delivery:Servicio
    {
        public string DireccionEnvio { get; set; }
        public double DistanciaARestaurante { get; set; }
        //public Repartidor Repartidor { get; set; }

        public Delivery()
        {
        }

        public Delivery(DateTime pFecha) : base(pFecha)
        {

        }
    }
}
