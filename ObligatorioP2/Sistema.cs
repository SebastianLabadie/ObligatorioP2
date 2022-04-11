using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class Sistema
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Delivery> deliverys = new List<Delivery>();
        private List<Local> locales = new List<Local>();
        private List<Plato> platos = new List<Plato>();
        private List<Repartidor> repartidores = new List<Repartidor>();
        private List<Mozo> mozos = new List<Mozo>();

        public Sistema()
        {
            Precaga();
            
        }

        private void Precaga()
        {

        }

        public Delivery AltaDelivery(DateTime pFch,string pDirEnvio, double pDisRestaurante, Repartidor pRepartidor)
        {
            Delivery nuevo = new Delivery(pFch, pDirEnvio, pDisRestaurante, pRepartidor);
            return nuevo;
        }

        public Local AltaLocal(DateTime pFecha, int pNroMesa, int pCantComensales, Mozo pMozo)
        {
            Local nuevo = new Local(pFecha, pNroMesa, pCantComensales,pMozo);
            return nuevo;
        }

        public Mozo AltaMozo(int pNroFuncionario, string pNombre, string pApellido)
        {
            Mozo nuevo = new Mozo(pNroFuncionario,pNombre,pApellido);
            return nuevo;
        }

        public Repartidor AltaRepartidor(TipoVehiculo pTpoVehiculo, string pNombre, string pApellido)
        {
            Repartidor nuevo = new Repartidor(pTpoVehiculo,pNombre,pApellido);
            return nuevo;
        }

        public Plato AltaPlato(string pNombre, int pPrecio)
        {
            Plato nuevo = new Plato(pNombre,pPrecio);
            return nuevo;
        }

        public Cliente AltaCliente(string pEmail, string pPassword, string pNombre, string pApellido)
        {
            Cliente nuevo = new Cliente(pEmail,pPassword,pNombre,pApellido);
            return nuevo;
        }

    }
}
