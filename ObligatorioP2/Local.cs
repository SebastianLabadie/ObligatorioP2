using System;
namespace Dominio
{
    public class Local: Servicio //Hereda de la clase Servicio sus atributos y funciones
    {

        //Atributos de la clase
        public int NroMesa { get; set; }
        public int CantComensales { get; set; }
        public static double PrecioCubierto;
        public Mozo Mozo { get; set; }

        //Constructor
        public Local(DateTime pFecha,int pNroMesa,int pCantComensales,Mozo pMozo) : base(pFecha)
        {
       
            this.NroMesa = pNroMesa;
            this.CantComensales = pCantComensales;
            this.Mozo = pMozo;
        }

        //override de funcion Validar para crear el objeto
        public override bool EsValido()
        {
            //Se crea si Numero de mesa es mayor a 0,la cantidad de comensales sea mayor a 0 y tenga un mozo
            if (NroMesa > 0 && CantComensales > 0 && Mozo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
