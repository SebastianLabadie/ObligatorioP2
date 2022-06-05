using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Usuario
    {
        public int IdPersona { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }

        public Usuario(int idPersona, string username, string password)
        {
            IdPersona = idPersona;
            Username = username;
            Password = password;
            Estado = true;
        }

    }
}
