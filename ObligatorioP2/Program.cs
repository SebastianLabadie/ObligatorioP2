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
        }
    }
}
