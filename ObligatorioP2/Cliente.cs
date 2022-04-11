using System;
namespace ObligatorioP2
{
    public class Cliente:Persona
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Cliente()
        {
        }

        public Cliente(int pId, string pNombre, string pApellido) : base(pId, pNombre, pApellido)
        {

        }
    }
}
