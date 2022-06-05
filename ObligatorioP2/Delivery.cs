using System;
namespace Dominio
{
    public class Delivery:Servicio //Esta clase tiene herencia de la clase Servicio, por lo que hereda sus atributos
    {

        //Se crean los atributos
        public string DireccionEnvio { get; set; }
        public double DistanciaARestaurante { get; set; }
        public Repartidor Repartidor { get; set; }



        //Constructor
        public Delivery(DateTime pFecha,string pDirEnvio,double pDisRestaurante,Repartidor pRepartidor) : base(pFecha)
        {
            this.DireccionEnvio = pDirEnvio;
            this.DistanciaARestaurante = pDisRestaurante;
            this.Repartidor = pRepartidor;
        }

        //Funcion para mostrar datos del objeto
        public override string ToString()
        {
            return "Fecha: " + this.Fecha + " Direccion de Envio: " + this.DireccionEnvio + " Distancia: " + this.DistanciaARestaurante + "KM" + " Repartidor: " + this.Repartidor.ToString();
        }

        //Override de la funcion EsValido que se encuentra en Servicio
        public override bool EsValido()
        {

            //Verficia si la direccion de envio no es vacio, la distancia es mayor a 0 y tenga Repartidor
            if (DireccionEnvio != "" && DistanciaARestaurante > 0 && Repartidor != null)
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
