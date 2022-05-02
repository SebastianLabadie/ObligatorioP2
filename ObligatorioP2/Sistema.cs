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
            TipoVehiculo t1 = AltaTipoVehiculo("Moto");
            TipoVehiculo t2 = AltaTipoVehiculo("Auto");
            TipoVehiculo t3 = AltaTipoVehiculo("Camion");
            Cliente cl = AltaCliente("pepe@gmail.com", "Ab123456", "PEPE", "PEPE");
            Cliente cl1 = AltaCliente("Jose@gmail.com", "Aa123456", "JOSE", "JOSE");
            Cliente cl3 = AltaCliente("raul@gmail.com", "Aa123456", "RAUL", "RAUL");
            Cliente cl4 = AltaCliente("jorge@gmail.com", "Aa123456", "JORGE", "JORGE");
            Cliente cl5 = AltaCliente("marcelo@gmail.com", "Aa123456", "MARCELO", "MARCELO");
            for (int i = 1; i<=10; i++)
            {
                Plato p1 = AltaPlato($"Plato {i}", 20+i);
                
                Mozo m1 = AltaMozo(120+i, $"Mozo {i}"+i, $"Mozo {i}");
                AltaLocal(DateTime.Now, 1, 4, m1);
                


                if (i < 3)
                {

                    Repartidor r1 = AltaRepartidor(t1, $"Repartidor {i}", $"Repartidor {i}");
                    Delivery d1 = AltaDelivery(DateTime.Now, "Comercio 2000", 1+i, r1);
                }
                      
                        
                        
                if(i< 7)
                {
                    Repartidor r2 = AltaRepartidor(t2, $"Repartidor {i}", $"Repartidor {i}");
                    Delivery d2 = AltaDelivery(DateTime.Now, "Comercio 2000", 1+i, r2);
                }



                if (i >= 7)
                {
                    Repartidor r3 = AltaRepartidor(t3, $"Repartidor {i}", $"Repartidor {i}");
                    Delivery d3 = AltaDelivery(DateTime.Now, "Comercio 2000", 1+i, r3);
                }
                    
                    
                }

            


        }

        public Delivery AltaDelivery(DateTime pFecha,string pDireccionEnvio, double pDistanciaRestaurante, Repartidor pRepartidor)
        {
            Delivery nuevo = new Delivery(pFecha, pDireccionEnvio, pDistanciaRestaurante, pRepartidor);
            if (nuevo.EsValido())
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
            if (nuevo.EsValido())
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

            if (nuevo.EsValido())
            {
                
                if (!nuevo.VerficiarNroFuncionario(mozos))
                {
                    mozos.Add(nuevo);
                    return nuevo;
                }
                else
                {
                    Console.WriteLine("Existe Mozo con Mismo numero de funcionario.");
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        public Repartidor AltaRepartidor(TipoVehiculo pTpoVehiculo, string pNombre, string pApellido)
        {
            Repartidor nuevo = new Repartidor(pTpoVehiculo,pNombre,pApellido);
            if (nuevo.EsValido())
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
            if (nuevo.EsValido())
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
            if (nuevo.EsValido())
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
            if (nuevo.EsValido() == true)
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

            if (platos.Count() > 0)
            {
                Console.WriteLine("Lista de Platos: ");
                foreach (Plato plato in platos)
                {
                    Console.WriteLine(plato.ToString());
                }
            }
            else
            {
                Console.WriteLine("No se encuentra registro de Platos.");
            }
        }

        public void ListarClientesPorNomApe()
        {
            if (clientes.Count() > 0)
            {

                clientes.Sort();


                foreach (Cliente cl in clientes)
                {
                    Console.WriteLine(cl.ToString());
                }
            }
            else
            {
                Console.WriteLine("No se encuentra registro de Clientes.");
            }
            //clientes.Sort();



        }

        public void ListarServiciosDeRepartidor()
        {


           

            Console.WriteLine("Ingrese Nombre de Repartidor");
            String NomRep = Console.ReadLine().ToUpper();

            Console.WriteLine("Ingrese Apellido de Repartidor");
            String ApellidoRep = Console.ReadLine().ToUpper();

            int pIdRep = 0;
            foreach (Repartidor rep in repartidores)
            {
               if (NomRep == rep.Nombre.ToUpper() && ApellidoRep == rep.Apellido.ToUpper())
                {
                    pIdRep = rep.Id;
                }
            }

            if (pIdRep == 0)
            {
                Console.WriteLine("No se encuentran repartidores con el Nombre " + NomRep + " y apellido " + ApellidoRep);
                return;
            }

            Console.WriteLine("Ingrese Fecha desde");
            DateTime pFchDesde = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("FEHCA ES " + pFchDesde);

            Console.WriteLine("Ingrese Fecha hasta");
            DateTime pFchHasta = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Lista de Servicios: ");

            List<Delivery> deliveriesFiltered = new List<Delivery>();


            foreach (Delivery delivery in deliverys)
            {
                if (delivery.Repartidor.Id == pIdRep && delivery.Fecha >= pFchDesde && delivery.Fecha <= pFchHasta)
                {
                    deliveriesFiltered.Add(delivery);
                }
            }

            if (deliveriesFiltered.Count == 0)
            {
                Console.WriteLine("No hay registros.");
            }
            else
            {
                foreach (Delivery delivery in deliveriesFiltered)
                {
                   Console.WriteLine(delivery.ToString());
                }
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

        public void AltaMozoPorUsuario()
        {
            Console.WriteLine("Ingrese Numero de Funcionario");
            int pNroFuncionario = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Nombre de Funcionario");
            string pNombre = Console.ReadLine();

            Console.WriteLine("Ingrese Apellido de Funcionario");
            string pApellido = Console.ReadLine();

            Mozo m = AltaMozo(pNroFuncionario,pNombre,pApellido);

            if (m == null)
            {
                Console.WriteLine("Mozo no creado.");
                
            }
            else
            {
                Console.WriteLine("Mozo " + m.ToString() + " Creado Correctamente.");
            }

        }






    }
}
