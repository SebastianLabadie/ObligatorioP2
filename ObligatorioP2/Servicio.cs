using System;
using System.Collections.Generic;

namespace ObligatorioP2
{
    public class Servicio
    {
        public DateTime fecha { get; set; }

        public List<Plato> platos = new List<Plato>();

        public Servicio()
        {
        }

        public Servicio(DateTime pFecha)
        {
            this.fecha = pFecha;
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

            return "fecha "+fecha.ToString()+" platos: "+platosInfo;
        }
    }
}
