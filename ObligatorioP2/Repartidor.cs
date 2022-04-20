using System;
namespace ObligatorioP2
{
    public class Repartidor:Persona,IValidacion
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

        public bool esValido()
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
