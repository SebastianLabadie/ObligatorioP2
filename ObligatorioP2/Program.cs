using System;

namespace ObligatorioP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Mozo m1 = new Mozo(1,1,"Mozo1","Mozo1");
            Mozo m2 = new Mozo(2, 2, "Mozo2", "Mozo2");
            Mozo m3 = new Mozo(3, 3, "Mozo3", "Mozo3");

            Console.WriteLine("MOZOS \n");
            Console.WriteLine(m1.ToString());
            Console.WriteLine(m2.ToString());
            Console.WriteLine(m3.ToString());

            Plato p1 = new Plato(1, "Plato1", 123);
            Plato p2 = new Plato(2, "Plato2", 123);
            Plato p3 = new Plato(3, "Plato3", 123);

            Servicio s1 = new Servicio(DateTime.Now);
            s1.agregarPlato(p1);
            s1.agregarPlato(p2);
            s1.agregarPlato(p3);

            Console.WriteLine("\nSERVICIO \n");
            Console.WriteLine(s1.ToString());
        }
    }
}
