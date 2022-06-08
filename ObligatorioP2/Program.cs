using System;
using System.Collections.Generic;

namespace Dominio
{
     class Program
     {
        static Sistema sis = Sistema.GetInstancia();
        static void Main(string[] args)
        {

            

            int op = -1;

            while (op !=0)
            {
                //tirar esto para metod menu

                Console.WriteLine("\n-------- MENU PRINCIPAL --------");
                Console.WriteLine("1-Listar Todos los Platos");
                Console.WriteLine("2-Listado de Clientes Ordenado por Apellido / Nombre");
                Console.WriteLine("3-Listado de los servicios entregados por un repartidor en un rango de fechas dado");
                Console.WriteLine("4-Modificar el valor del precio mínimo del plato");
                Console.WriteLine("5-Alta de Mozo");
                Console.WriteLine("0-Salir");

                op = Int32.Parse(Console.ReadLine());

               // Console.Clear();

                switch (op)
                {
                    case 1:
                        ListarPlatos();
                        break;

                    case 2:
                        ListarClientesPorNomApe();    
                        break;

                    case 3:
                        ListarServiciosDeRepartidor();
                        break;

                    case 4:
                        ModificarPrecioMinimoPlatos();
                        break;

                    case 5:
                        AltaMozoPorUsuario();
                        break;
                    case 0:
                        Console.WriteLine("Adios!");
                        break;

                    default:
                        Console.WriteLine("INGRESE UNA OPCION CORRECTA.");
                        break;

                }

            }

            


        }

       

        public static void ListarPlatos()
        {
            List<Plato> ret = new List<Plato>();
            ret = sis.GetPlatos();
            if (ret.Count > 0)
            {
                foreach (Plato plato in ret)
                {
                    Console.WriteLine(plato.ToString());
                }
            }
            else
            {
                Console.WriteLine("No se encuentra registro de Platos.");
            }


        }

        public static void ListarClientesPorNomApe()
        {
            List<Cliente> ret = new List<Cliente>();
            ret = sis.GetClientesPorNomApe();
            if (ret.Count > 0)
            {
                foreach (Cliente item in ret)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("No se encuentra registro de Clientes.");
            }


        }

        public static void ListarServiciosDeRepartidor()
        {

            //Se pide ingreso de Datos
            Console.WriteLine("Ingrese Nombre de Repartidor");
            String NomRep = Console.ReadLine().ToUpper();

            Console.WriteLine("Ingrese Apellido de Repartidor");
            String ApellidoRep = Console.ReadLine().ToUpper();

            int id = sis.GetRepartidor(NomRep,ApellidoRep);
            
            //Si el Id del repartidor es 0 significa que no se encuentra un repartidor
            if (id == 0)
            {
                Console.WriteLine("No se encuentran repartidores con el Nombre " + NomRep + " y apellido " + ApellidoRep);

            }
            else
            {
                Console.WriteLine("Ingrese Fecha desde");
                DateTime pFchDesde = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese Fecha hasta");
                DateTime pFchHasta = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Lista de Servicios: ");

                List<Delivery> ret = new List<Delivery>();
                ret = sis.GetServiciosDeRepartidor(id, pFchDesde, pFchHasta);

                //En el caso que no coinicidan con el filtro y la lista sea vacia, devuelve mensaje de error
                if (ret.Count == 0)
                {
                    Console.WriteLine("No hay registros.");
                }
                else
                {
                    foreach (Delivery delivery in ret)
                    {
                        Console.WriteLine(delivery.ToString());
                    }
                }
            }


            


        }


        public static void ModificarPrecioMinimoPlatos()
        {
            Console.WriteLine("Ingrese nuevo precio MINIMO de Platos:");
            string linestr = Console.ReadLine();
            string ret = sis.ModificarPrecioMinimoPlatos(linestr);
            Console.WriteLine(ret);

        }


        public static void AltaMozoPorUsuario()
        {

            //Pido los datos por pantalla
            Console.WriteLine("Ingrese Numero de Funcionario");
            int pNroFuncionario = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Nombre de Funcionario");
            string pNombre = Console.ReadLine();

            Console.WriteLine("Ingrese Apellido de Funcionario");
            string pApellido = Console.ReadLine();

            //Llama al proceso crear Mozo
            Mozo m = sis.AltaMozo(pNroFuncionario, pNombre, pApellido);

            //En el caso que no se cree el mozo devuelve mensaje de error
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
