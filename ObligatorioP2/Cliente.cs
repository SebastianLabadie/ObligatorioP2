using System;
namespace ObligatorioP2
{
    public class Cliente:Persona
    {
        public string Email { get; set; }
        public string Password { get; set; }

       
        public Cliente(string pEmail,string pPassword,string pNombre, string pApellido) : base(pNombre, pApellido)
        {
            this.Email = pEmail;
            this.Password = pPassword;


        }
    }
}
