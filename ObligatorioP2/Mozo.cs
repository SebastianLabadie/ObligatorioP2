using System;
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
    }
}
