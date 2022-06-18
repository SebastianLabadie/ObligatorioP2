using System;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public class Delivery:Servicio,IComparable<Delivery> //Esta clase tiene herencia de la clase Servicio, por lo que hereda sus atributos
    {

        //Se crean los atributos
        public string DireccionEnvio { get; set; }
        public double DistanciaARestaurante { get; set; }
        public Repartidor Repartidor { get; set; }



        //Constructor
        public Delivery(DateTime pFecha,string pDirEnvio,double pDisRestaurante,Repartidor pRepartidor,Cliente cliente) : base(pFecha,cliente)
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

        public override double CalcularCosto()
        {
            double costo = 0;
            foreach (PlatoCantidad pc in carrito)
            {
                costo += pc.Plato.Precio * pc.Cantidad;
                
            }

            return costo;
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

       

        public int CompareTo([AllowNull] Delivery other)
        {

            if (Fecha.CompareTo(other.Fecha) > 0)
            {
                return -1;
            }
            else if (Fecha.CompareTo(other.Fecha) < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
