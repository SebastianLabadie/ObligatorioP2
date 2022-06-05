using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Mozo : Persona //Hereda de Persona
    {
        //Se crea atributo de la clase
        public int NroFuncionario { get; set; }

        //Constructor
        public Mozo(int pNroFuncionario,string pNombre,string pApellido) : base(pNombre,pApellido)
        {
            this.NroFuncionario = pNroFuncionario;
            
        }

        //Funcion para mostrar datos del objeto
        public override string ToString()
        {
            return "nroFuncionario: " +this.NroFuncionario+" id: "+this.Id+" nombre: "+this.Nombre+" apellido: "+this.Apellido;
        }

        //Verificar si el numero de funcionario no se encuentra ya ingresado en el sistema
        public bool VerficiarNroFuncionario(List<Mozo> ListMozo)
        {
            bool Existe = false;
            foreach (Mozo m in ListMozo)//Recorro lista de mozos
            {
                if (m.NroFuncionario == this.NroFuncionario) //Verifico que numero de funcionario de la lsita no sea igual al del objeto
                {
                    Existe = true;
                }
                
            }
            return Existe;
            
        }
        //Validaciones para crear objeto 
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
