using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public abstract class Servicio:IValidacion
    {
        public static int UltimoId;

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        private List<Plato> platos = new List<Plato>();


        public Servicio(DateTime pFecha)
        {
            this.Id = UltimoId;
            UltimoId++;
            this.Fecha = pFecha;
        }

    

        public void agregarPlato(Plato unPlato)
        {
            platos.Add(unPlato);
        }

        public override string ToString()
        {
            string platosInfo = "";
            foreach (Plato p in platos)
            {
                platosInfo += p.ToString()+", ";
            }

            return "fecha "+Fecha.ToString()+" platos: "+platosInfo;
        }

        public abstract bool EsValido();
    }
}
