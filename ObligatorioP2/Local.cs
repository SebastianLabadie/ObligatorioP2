using System;
namespace ObligatorioP2
{
    public class Local: Servicio
    {
        public int NroMesa { get; set; }
        public int CantComensales { get; set; }
        public static double PrecioCubierto;
        public Mozo Mozo { get; set; }


        public Local(DateTime pFecha,int pNroMesa,int pCantComensales,Mozo pMozo) : base(pFecha)
        {
       
            this.NroMesa = pNroMesa;
            this.CantComensales = pCantComensales;
            this.Mozo = pMozo;
        }
    }
}
