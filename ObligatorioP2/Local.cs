using System;
namespace ObligatorioP2
{
    public class Local: Servicio
    {
        public int NroMesa { get; set; }
        public int CantComensales { get; set; }
        public static double PrecioCubierto;
        public Mozo Mozo { get; set; }


        public Local()
        {
        }

        public Local(DateTime pFecha) : base(pFecha)
        {

        }
    }
}
