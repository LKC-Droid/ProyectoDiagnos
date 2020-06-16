using System;
using System.Collections.Generic;
using System.Text;

namespace Diagnos
{
    class Presupuesto
    {
        private int id;
        private int nRadiografias;
        private string especificaciones;
        private string observaciones;

        public int Id { get => id; set => id = value; }
        public int NRadiografias { get => nRadiografias; set => nRadiografias = value; }
        public string Especificaciones { get => especificaciones; set => especificaciones = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }

        public void init()
        {
            Id = 0;
            NRadiografias = 0;
            Especificaciones = string.Empty;
            Observaciones = string.Empty;
        }

        public Presupuesto()
        {

        }

        public Presupuesto(int nRadio, string especificaciones, string observaciones)
        {
            NRadiografias = nRadio;
            Especificaciones = especificaciones;
            Observaciones = observaciones;
        }

        public Presupuesto(int id, int nRadio, string especificaciones, string observaciones)
        {
            Id = id;
            NRadiografias = nRadio;
            Especificaciones = especificaciones;
            Observaciones = observaciones;
        }

        public Presupuesto(Presupuesto p)
        {
            Id = p.id;
            NRadiografias = p.nRadiografias;
            Especificaciones = p.especificaciones;
            Observaciones = p.observaciones;
        }


    }
}
