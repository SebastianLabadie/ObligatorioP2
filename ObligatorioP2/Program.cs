using System;

namespace ObligatorioP2
{
    class Program
    {
        static void Main(string[] args)
        {

            Sistema sis = new Sistema();

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
                        sis.ListarPlatos();
                        break;

                    case 2:
                        sis.ListarClientesPorNomApe();    
                        break;

                    case 3:
                        sis.ListarServiciosDeRepartidor();
                        break;

                    case 4:
                        sis.ModificarPrecioMinimoPlatos();
                        break;

                    case 5:
                        Console.WriteLine("EL 5");
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
    }
}
