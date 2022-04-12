using System;
namespace ObligatorioP2
{
    public class Delivery:Servicio
    {
        public string DireccionEnvio { get; set; }
        public double DistanciaARestaurante { get; set; }
        public Repartidor Repartidor { get; set; }

    
        public Delivery(DateTime pFecha,string pDirEnvio,double pDisRestaurante,Repartidor pRepartidor) : base(pFecha)
        {
            this.DireccionEnvio = pDirEnvio;
            this.DistanciaARestaurante = pDisRestaurante;
            this.Repartidor = pRepartidor;
        }

        public override string ToString()
        {
            return "Fecha: " + this.Fecha + " Direccion de Envio: " + this.DireccionEnvio + "Distancia: " + this.DistanciaARestaurante + "KM" + " Repartidor: " + this.Repartidor.ToString();
        }
    }
}
