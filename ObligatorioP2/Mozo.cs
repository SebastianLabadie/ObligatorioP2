using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class Mozo : Persona
    {
        public int NroFuncionario { get; set; }

      
        public Mozo(int pNroFuncionario,string pNombre,string pApellido) : base(pNombre,pApellido)
        {
            this.NroFuncionario = pNroFuncionario;
            
        }

        public override string ToString()
        {
            return "nroFuncionario: " +this.NroFuncionario+" id: "+this.Id+" nombre: "+this.Nombre+" apellido: "+this.Apellido;
        }

        public bool VerficiarNroFuncionario(List<Mozo> ListMozo)
        {
            bool Existe = false;
            foreach (Mozo m in ListMozo)
            {
                if (m.NroFuncionario == this.NroFuncionario)
                {
                    Existe = true;
                }
                
            }
            return Existe;
            
        }

        public override bool EsValido()
        {

            if (Nombre != "" && Apellido != "" && NroFuncionario > 0)
            {
                return true;
            }
            else
                return false;
        }

        
    }
}
