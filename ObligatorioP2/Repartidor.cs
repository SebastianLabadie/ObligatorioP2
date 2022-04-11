using System;
namespace ObligatorioP2
{
    public class Repartidor:Persona
    {
       public TipoVehiculo TipoVehiculo { get; set; }

        public Repartidor()
        {
        }

        public Repartidor(int pId, string pNombre, string pApellido) : base(pId, pNombre, pApellido)
        {

        }
    }
}
