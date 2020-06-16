using System;
using System.Collections.Generic;
using System.Text;

namespace Diagnos.Modelos.DTO
{
    class CitaMedica
    {
        private int id;
        private DateTime fecha;
        private Paciente paciente;
        //public Especialista esp;
        public DateTime Fecha { get => fecha; set => fecha = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        public int Id { get => id; set => id = value; }

        public void Init()
        {
            id = 0;
            Fecha = new DateTime(1900, 1, 1, 0, 00, 00);
            Paciente Paciente = new Paciente(paciente);
            //Especialista Espl = new Especialista(esp);
        }

        public CitaMedica(int id,DateTime fc, Paciente p)
        {
            Id = id;
            Fecha = fc;
            Paciente = p;
        }


    }
}
