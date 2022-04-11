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

        public Delivery AltaDelivery()
        {
            Delivery nuevo = new Delivery();
            return nuevo;
        }

        public Local AltaLocal()
        {
            Local nuevo = new Local();
            return nuevo;
        }

        public Mozo AltaMozo()
        {
            Mozo nuevo = new Mozo();
            return nuevo;
        }

        public Repartidor AltaRepartidor()
        {
            Repartidor nuevo = new Repartidor();
            return nuevo;
        }

        public Plato AltaPlato()
        {
            Plato nuevo = new Plato();
            return nuevo;
        }

        public Cliente AltaCliente()
        {
            Cliente nuevo = new Cliente();
            return nuevo;
        }

    }
}
