using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Sistema
    {
        //Creamos todas las listas
        private List<Cliente> clientes = new List<Cliente>();
        private List<Delivery> deliverys = new List<Delivery>();
        private List<Local> locales = new List<Local>();
        private List<Plato> platos = new List<Plato>();
        private List<Repartidor> repartidores = new List<Repartidor>();
        private List<Mozo> mozos = new List<Mozo>();

        public List<Servicio> GetServicios()
        {
            List<Servicio> ret = new List<Servicio>();
            foreach (Delivery d in deliverys)
            {
                ret.Add(d);
            }
            foreach (Local l in locales)
            {
                ret.Add(l);
            }
            return ret;
        }

        private List<TipoVehiculo> tipovehiculos = new List<TipoVehiculo>();

        private List<Usuario> usuarios = new List<Usuario>();
        private List<Persona> personas = new List<Persona>();

        private static Sistema instancia = null;

        public Sistema()
        {
            Precaga();
            
        }

        public static Sistema GetInstancia()
        {

            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }

        public Persona ValidarDatosLogin(string user, string pass)
        {
            Persona p = null;
            foreach (Usuario u in usuarios)
            {

                if (u.Username.Equals(user) && u.Password.Equals(pass) && u.Estado)
                {

                    p = GetPersona(u.IdPersona);
                }
            }
            return p;
        }

        public Persona GetPersona(int idPersona)
        {
            foreach (Persona p in personas)
            {
                if (p.Id.Equals(idPersona))
                {
                    return p;
                }
            }
            return null;
        }

        private void Precaga()
        {
            //Realizamos la precarga de datos

           
            Servicio.UltimoId = 1; 
            Plato.UltimoId = 1;
            TipoVehiculo.UltimoId = 1;
            Persona.UltimoId = 1;
            Plato.precioMinimo = 123;
            Local.PrecioCubierto = 123;
            TipoVehiculo t1 = AltaTipoVehiculo("Moto");
            TipoVehiculo t2 = AltaTipoVehiculo("Auto");
            TipoVehiculo t3 = AltaTipoVehiculo("Camion");
            Cliente cl = AltaCliente("pepe@gmail.com", "Ab123456", "PEPE", "PEPE");
            Cliente cl1 = AltaCliente("Jose@gmail.com", "Aa123456", "JOSE", "JOSE");
            Cliente cl3 = AltaCliente("raul@gmail.com", "Aa123456", "RAUL", "RAUL");
            Cliente cl4 = AltaCliente("jorge@gmail.com", "Aa123456", "JORGE", "JORGE");
            Cliente cl5 = AltaCliente("marcelo@gmail.com", "Aa123456", "MARCELO", "MARCELO");
            for (int i = 1; i<=10; i++)
            {
                Plato p1 = AltaPlato($"Plato {i}", 20+i);
                
                Mozo m1 = AltaMozo(120+i, $"Mozo {i}"+i, $"Mozo {i}");
                AltaLocal(DateTime.Now, 1, 4, m1);
                

                //Esto se reliza para poder crear distintos Repartidores con diferente nombre.
                if (i < 3)
                {

                    Repartidor r1 = AltaRepartidor(t1, $"Repartidor {i}", $"Repartidor {i}");
                    Delivery d1 = AltaDelivery(DateTime.Now, "Comercio 2000", 1+i, r1);
                }
                      
                        
                        
                if(i< 7)
                {
                    Repartidor r2 = AltaRepartidor(t2, $"Repartidor {i}", $"Repartidor {i}");
                    Delivery d2 = AltaDelivery(DateTime.Now, "Comercio 2000", 1+i, r2);
                }



                if (i >= 7)
                {
                    Repartidor r3 = AltaRepartidor(t3, $"Repartidor {i}", $"Repartidor {i}");
                    Delivery d3 = AltaDelivery(DateTime.Now, "Comercio 2000", 1+i, r3);
                }
                    
                    
                }

            


        }

        public Delivery AltaDelivery(DateTime pFecha,string pDireccionEnvio, double pDistanciaRestaurante, Repartidor pRepartidor)
        {

            //Creamos el objeto nuevo
            Delivery nuevo = new Delivery(pFecha, pDireccionEnvio, pDistanciaRestaurante, pRepartidor);

            //En caso de ser valido el objeto creado, se agrega a la lista, sino devuelve nulo
            if (nuevo.EsValido())
            {
                deliverys.Add(nuevo); //Se agrega a la lista
                return nuevo;
            }
            else
            {
                return null;
            }
                
            
        }

        public Local AltaLocal(DateTime pFecha, int pNroMesa, int pCantComensales, Mozo pMozo)
        {

            Local nuevo = new Local(pFecha, pNroMesa, pCantComensales,pMozo);

            //En caso de ser valido el objeto creado, se agrega a la lista, sino devuelve nulo
            if (nuevo.EsValido())
            {
                locales.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }
                
            
        }

        public Mozo AltaMozo(int pNroFuncionario, string pNombre, string pApellido)
        {

            Mozo nuevo = new Mozo(pNroFuncionario,pNombre,pApellido);
            //En caso de ser valido el objeto creado, se agrega a la lista, sino devuelve nulo
            if (nuevo.EsValido())
            {

                //Si el Numero de funcionario no existe en otro Mozo, se agrega
                if (!nuevo.VerficiarNroFuncionario(mozos))
                {
                    mozos.Add(nuevo);
                    personas.Add(nuevo);
                    Usuario u = new Usuario(nuevo.Id, pNombre, pNombre);
                    usuarios.Add(u);
                    return nuevo;
                }
                else
                {
                    Console.WriteLine("Existe Mozo con Mismo numero de funcionario.");
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        public Repartidor AltaRepartidor(TipoVehiculo pTpoVehiculo, string pNombre, string pApellido)
        {
            Repartidor nuevo = new Repartidor(pTpoVehiculo,pNombre,pApellido);

            //En caso de ser valido el objeto creado, se agrega a la lista, sino devuelve nulo
            if (nuevo.EsValido())
            {
                repartidores.Add(nuevo);
                personas.Add(nuevo);
                Usuario u = new Usuario(nuevo.Id, pNombre, pNombre);
                usuarios.Add(u);
                return nuevo;
            }
            else
            {
                return null;
            }
        }

        public Plato AltaPlato(string pNombre, int pPrecio)
        {
            Plato nuevo = new Plato(pNombre,pPrecio);

            //En caso de ser valido el objeto creado, se agrega a la lista, sino devuelve nulo
            if (nuevo.EsValido())
            {
                platos.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }
        }

        public Cliente AltaCliente(string pEmail, string pPassword, string pNombre, string pApellido)
        {

            Cliente nuevo = new Cliente(pEmail,pPassword,pNombre,pApellido);

            //En caso de ser valido el objeto creado, se agrega a la lista, sino devuelve nulo
            if (nuevo.EsValido())
            {
                clientes.Add(nuevo);
                personas.Add(nuevo);
                Usuario u = new Usuario(nuevo.Id, pNombre, pPassword);
                usuarios.Add(u);
                return nuevo;

            }
            else
            {
                return null;
            }
               
                
            
        }


        public TipoVehiculo AltaTipoVehiculo(string pNombre)
        {
            TipoVehiculo nuevo = new TipoVehiculo(pNombre);

            //En caso de ser valido el objeto creado, se agrega a la lista, sino devuelve nulo
            if (nuevo.EsValido() == true)
            {
                tipovehiculos.Add(nuevo);
                return nuevo;

            }
            else
            {
                return null;
            }
                

        }

        public List<Plato> GetPlatos() 
        {
            List<Plato> ret = new List<Plato>();
            
            //Si existen Objetos de tipo Plato en la lista platos, se van a mostrar en pantalla, sino devuelve mensaje
            if (platos.Count() > 0)
            {
                
                foreach (Plato plato in platos)
                {
                    ret.Add(plato);
                }
            }
           
            return ret;
        }

        public List<Plato> getListaPlatos()
        {
            List<Plato> ret = new List<Plato>();
            //Si existen Objetos de tipo Plato en la lista platos, se van a mostrar en pantalla, sino devuelve mensaje
            if (platos.Count() > 0)
            {
                platos.Sort();
                ret = platos;
            }

            return ret;
        }


        public List<Cliente> GetClientesPorNomApe()
        {

            List<Cliente> ret = new List<Cliente>();
            //Si existen Objetos de Tipo Cliente en la lista cliente, se va a realizar un Sort y mostrar por pantalla
            
            clientes.Sort(); //Se realiza para ordenar la lista 


            foreach (Cliente cl in clientes) //Recorremos la lista de clientes
            {
                ret.Add(cl);
            }


            return ret;
            
        }

        public int GetRepartidor(string NomRep, string ApellidoRep)
        {
           
            int pIdRep = 0;
            
            //Con el Nombre y apellido solicitado anteriormente, vamos a buscar el Id del repartidor
            foreach (Repartidor rep in repartidores)
            {
                if (NomRep == rep.Nombre.ToUpper() && ApellidoRep == rep.Apellido.ToUpper())
                {
                    pIdRep = rep.Id;
                }
            }

            return pIdRep;

        }

        public List<Delivery> GetServiciosDeRepartidor(int pIdRep,DateTime pFchDesde,DateTime pFchHasta)
        {

            List<Delivery> deliveriesFiltered = new List<Delivery>(); //Se crea una nueva lista para devolverla ordenadad


            foreach (Delivery delivery in deliverys)
            {
                //Si el objeto Delivery coincide con el Id del repartidor y el rango de fechas, se agrega a la nueva lista

                if (delivery.Repartidor.Id == pIdRep && delivery.Fecha >= pFchDesde && delivery.Fecha <= pFchHasta)
                {
                    deliveriesFiltered.Add(delivery);
                }
            }

            return deliveriesFiltered;

        }

        public string ModificarPrecioMinimoPlatos(string linestr)
        {


            string msg = "";

            //Expresion regular para verificar que el dato ingresado sea numerico
            if (Regex.IsMatch(linestr, @"^[0-9]+$"))
            {

                int line = Int32.Parse(linestr);

                if (line > 0)
                {
                    Plato.precioMinimo = line; //Actualizo el precio minimo del Plato
                    msg = "El Precio Minimo se actualizo a " + Plato.precioMinimo;
                }
                else
                {
                    msg = "Ingrese un valor mayor a 0";
                }

            }
            else
            {
                msg = "Ingrese un valor numerico.";
            }

            return msg;

        }

        

        public void Likear(int id)
        {
            foreach (Plato p in platos)
            {
                if (p.Id.Equals(id))
                {
                    p.Likes++;
                }
            }
        }

    }
}
