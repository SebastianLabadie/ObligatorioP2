using System;
namespace Dominio
{
    public class Repartidor : Persona
    {
       public TipoVehiculo TipoVehiculo { get; set; }

    
        public Repartidor(TipoVehiculo pTpoVehiculo,string pNombre, string pApellido) : base(pNombre, pApellido)
        {
            this.TipoVehiculo = pTpoVehiculo;

        }

        public override string ToString()
        {
            return  base.ToString();
        }

        public override bool EsValido()
        {
            if (Nombre != "" && Apellido != "" && TipoVehiculo != null)
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
