using System;
namespace ObligatorioP2
{
    public class Repartidor:Persona
    {
       public TipoVehiculo TipoVehiculo { get; set; }

    
        public Repartidor(TipoVehiculo pTpoVehiculo,string pNombre, string pApellido) : base(pNombre, pApellido)
        {
            this.TipoVehiculo = pTpoVehiculo;

        }
    }
}
