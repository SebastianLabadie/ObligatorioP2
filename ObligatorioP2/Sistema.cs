using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        private List<TipoVehiculo> tipovehiculos = new List<TipoVehiculo>();

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
            Cliente cl = AltaCliente("pepe@gmail.com", "Ab123456", "C", "PEPE");
            Cliente cl1 = AltaCliente("Jose@gmail.com", "Aa123456", "B", "ANGEL");
            Cliente cl3 = AltaCliente("Jose@gmail.com", "Aa123456", "A", "ANGEL");
        }

        public Delivery AltaDelivery(DateTime pFecha,string pDireccionEnvio, double pDistanciaRestaurante, Repartidor pRepartidor)
        {
            Delivery nuevo = new Delivery(pFecha, pDireccionEnvio, pDistanciaRestaurante, pRepartidor);
            if (nuevo.esValido())
            {
                deliverys.Add(nuevo);
                return nuevo;
            }
            else
            {
                return null;
            }
                
            
        }

        public Local AltaLocal(DateTime pFecha, int pNroMesa, int pCantComensales, Mozo pMozo)
        {

            Local nuevo = new Local(pFecha, pNroMesa, pCantComensales,pMozo);
            if (nuevo.esValido())
            {
                locales.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }
                
            
        }

        public Mozo AltaMozo(int pNroFuncionario, string pNombre, string pApellido)
        {

            Mozo nuevo = new Mozo(pNroFuncionario,pNombre,pApellido);

            if (nuevo.esValido())
            {
                mozos.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }

        }

        public Repartidor AltaRepartidor(TipoVehiculo pTpoVehiculo, string pNombre, string pApellido)
        {
            Repartidor nuevo = new Repartidor(pTpoVehiculo,pNombre,pApellido);
            if (nuevo.esValido())
            {
                repartidores.Add(nuevo);
                return nuevo;
            }
            else
            {
                return null;
            }
        }

        public Plato AltaPlato(string pNombre, int pPrecio)
        {
            Plato nuevo = new Plato(pNombre,pPrecio);
            if (nuevo.esValido())
            {
                platos.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }
        }

        public Cliente AltaCliente(string pEmail, string pPassword, string pNombre, string pApellido)
        {

            Cliente nuevo = new Cliente(pEmail,pPassword,pNombre,pApellido);
            if (nuevo.esValido())
            {
                clientes.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }
               
                
            
        }


        public TipoVehiculo AltaTipoVehiculo(string pNombre)
        {
            TipoVehiculo nuevo = new TipoVehiculo(pNombre);
            if (nuevo.esValido() == true)
            {
                tipovehiculos.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }
                

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
            clientes.Sort();


            foreach (Cliente cl in clientes)
            {
                Console.WriteLine(cl.ToString());
            }
            //clientes.Sort();



        }

        public void ListarServiciosDeRepartidor(int pIdRep)
        {
            Console.WriteLine("Lista de Servicios: ");

            List<Delivery> deliveriesFiltered = deliverys.FindAll(e => e.Repartidor.Id == pIdRep);


            foreach (Delivery delivery in deliveriesFiltered)
            {
                Console.WriteLine(delivery.ToString());
            }
        }

        public void ModificarPrecioMinimoPlatos()
        {
            Console.WriteLine("Ingrese nuevo precio MINIMO de Platos:");

            string linestr = Console.ReadLine();

            if (Regex.IsMatch(linestr, @"^[0-9]+$"))
            {

                int line = Int32.Parse(linestr);

                if (line > 0)
                {
                    Plato.precioMinimo = line;
                    Console.WriteLine("El Precio Minimo se actualizo a " + Plato.precioMinimo);
                }
                else
                {
                    Console.WriteLine("Ingrese un valor mayor a 0");
                }

            }
            else
            {
                Console.WriteLine("Ingrese unn valor numerico.");
            }

            

        }




    }
}
