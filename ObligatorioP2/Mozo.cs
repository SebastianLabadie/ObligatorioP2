using System;
namespace ObligatorioP2
{
    public class Mozo : Persona
    {
        public int nroFuncionario { get; set; }

        public Mozo(int pNroFuncionario, int pId,string pNombre,string pApellido) : base(pId,pNombre,pApellido)
        {
            this.nroFuncionario = pNroFuncionario;
        }

        public override string ToString()
        {
            return "nroFuncionario: " +this.nroFuncionario+" id: "+this.id+" nombre: "+this.nombre+" apellido: "+this.apellido;
        }
    }
}
