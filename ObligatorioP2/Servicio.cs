using System;
using System.Collections.Generic;

namespace Dominio
{
    public abstract class Servicio:IValidacion //Se crea la clase abstracta para de esta forma no poder crear un objeto de este tipo en el codigo
    {
        public static int UltimoId; //Se crea un atributo estatico de la clase

        public int Id { get; set; } //Se crea los atributos de la clase

        public string Estado { get; set; } //Abierto, Cerrado

        public DateTime Fecha { get; set; }

        private List<PlatoCantidad> carrito = new List<PlatoCantidad>();


        //Constructor por fecha
        public Servicio(DateTime pFecha)
        {
            this.Id = UltimoId;
            UltimoId++; //Se autonumera el Id al crear un nuevo objeto se agrega 1 al ultimoid
            this.Fecha = pFecha;
            this.Estado = "Abierto";
        }

    
        //Se agrega el plato a la lista platos,enviando por parametro el objeto Plato
        public void agregarPlato(PlatoCantidad unPlato)
        {
            carrito.Add(unPlato);
        }

        //Se realiza un overrride a la funcion ToString para permitir mostrar datos de cada objeto en el que se llame esta funcion
        public override string ToString()
        {
            string platosInfo = "";
            foreach (PlatoCantidad p in carrito)
            {
                platosInfo += p.ToString()+", ";
            }

            return "fecha "+Fecha.ToString()+" platos: "+platosInfo;
        }

        public abstract bool EsValido(); //Se defune una funcion Abstracta para utilizar en las clases hijas que se generen.
    }
}
