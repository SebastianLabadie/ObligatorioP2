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
                Console.WriteLine("1-Listar Todos los Platos");
                Console.WriteLine("2-Listado de Clientes Ordenado por Apellido / Nombre");
                Console.WriteLine("3-Listado de los servicios entregados por un repartidor en un rango de fechas dado");
                Console.WriteLine("4-Modificar el valor del precio mínimo del plato");
                Console.WriteLine("5-Alta de Mozo");
                Console.WriteLine("0-Salir");

                op = Int32.Parse(Console.ReadLine());


                switch (op)
                {
                    case 1:
                        Console.WriteLine("el 1");
                        break;

                    case 2:
                        Console.WriteLine("EL 2");    
                        break;

                    case 3:
                        Console.WriteLine("EL 3");
                        break;

                    case 4:
                        Console.WriteLine("EL 4");
                        break;

                    case 5:
                        Console.WriteLine("EL 5");
                        break;
                    case 0:
                        Console.WriteLine("EL 0");
                        break;

                    default:
                        Console.WriteLine("INGRESE UNA OPCION CORRECTA.");
                        break;

                }

            }

           


        }
    }
}
