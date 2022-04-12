using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class Sistema
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Delivery> deliverys = new List<Delivery>();
        private List<Local> locales = new List<Local>();
        private List<Plato> platos = new List<Plato>();
        private List<Repartidor> repartidores = new List<Repartidor>();
        private List<Mozo> mozos = new List<Mozo>();

        public Sistema()
        {
            Precaga();
            
        }

        private void Precaga()
        {
            Servicio.UltimoId = 1;
            Plato.UltimoId = 1;
            TipoVehiculo.UltimoId = 1;
            Persona.UltimoId = 1;
            Plato.precioMinimo = 123;
            Local.PrecioCubierto = 123;

            Plato p1 = AltaPlato("Plato 1",22);
            Plato p2 = AltaPlato("Plato 2", 33);
            Plato p3 = AltaPlato("Plato 3", 44);
            Mozo m1 = AltaMozo(123,"Mozo 1","Mozo 1");
            TipoVehiculo t1 = new TipoVehiculo("Moto");
            Repartidor r1 = AltaRepartidor(t1,"Repartidor 1","Repartidor 1");
            Delivery d1 = AltaDelivery(DateTime.Now,"Soca 1542",5,r1);
            AltaLocal(DateTime.Now,1,4,m1);
            
        }

        public Delivery AltaDelivery(DateTime pFecha,string pDireccionEnvio, double pDistanciaRestaurante, Repartidor pRepartidor)
        {
            Delivery nuevo = new Delivery(pFecha, pDireccionEnvio, pDistanciaRestaurante, pRepartidor);
            deliverys.Add(nuevo);
            return nuevo;
        }

        public Local AltaLocal(DateTime pFecha, int pNroMesa, int pCantComensales, Mozo pMozo)
        {
            Local nuevo = new Local(pFecha, pNroMesa, pCantComensales,pMozo);
            locales.Add(nuevo);
            return nuevo;
        }

        public Mozo AltaMozo(int pNroFuncionario, string pNombre, string pApellido)
        {
            Mozo nuevo = new Mozo(pNroFuncionario,pNombre,pApellido);
            mozos.Add(nuevo);
            return nuevo;
        }

        public Repartidor AltaRepartidor(TipoVehiculo pTpoVehiculo, string pNombre, string pApellido)
        {
            Repartidor nuevo = new Repartidor(pTpoVehiculo,pNombre,pApellido);
            repartidores.Add(nuevo);
            return nuevo;
        }

        public Plato AltaPlato(string pNombre, int pPrecio)
        {
            Plato nuevo = new Plato(pNombre,pPrecio);
            platos.Add(nuevo);
            return nuevo;
        }

        public Cliente AltaCliente(string pEmail, string pPassword, string pNombre, string pApellido)
        {
            Cliente nuevo = new Cliente(pEmail,pPassword,pNombre,pApellido);
            clientes.Add(nuevo);
            return nuevo;
        }

        public void ListarPlatos()
        {
            Console.WriteLine("Lista de Platos: ");
            foreach (Plato plato in platos)
            {
                Console.WriteLine(plato.ToString());
            }
        }

        public void ListarClientesPorNomApe()
        {
           
        }

        public void ListarServiciosDeRepartidor(int pIdRep)
        {
            Console.WriteLine("Lista de Servicios: ");

            List<Delivery> filtered = deliverys.FindAll(e => e.Repartidor.Id == pIdRep);


            foreach (Delivery delivery in deliverys)
            {
               
            }
        }

        public void ModificarPrecioMinimoPlatos()
        {

        }


    }
}
