using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Cliente : Persona
    {
        public string Email { get; set; }
        public string Password { get; set; }

       
        public Cliente(string pEmail,string pPassword,string pNombre, string pApellido) : base(pNombre, pApellido)
        {
            this.Email = pEmail;
            this.Password = pPassword;


        }
        public override bool EsValido()
        {
            
            if (Nombre != "" && Apellido != "" && Regex.IsMatch(Password, "[A-Z]+[a-z]+[0-9]") && Password.Length>=6 && Regex.IsMatch(Nombre, "[A-Z]|[a-z]") && Regex.IsMatch(Apellido, "[A-Z]|[a-z]") && Regex.IsMatch(Email, "[@]") && Email.Substring(0,1)!="@" && Email.Substring(Email.Length-1)!="@")
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
