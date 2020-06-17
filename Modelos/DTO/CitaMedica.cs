using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ProyectoDiagnos.Modelos.DTO
{
    class CitaMedica
    {
        private int id;
        private DateTime fecha;
        private Paciente paciente;
        private string estado;
        //public Especialista esp;
        public DateTime Fecha { get => fecha; set => fecha = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        public int Id { get => id; set => id = value; }
        public string Estado { get => estado; set => estado = value; }

        public void Init()
        {
            id = 0;
            Fecha = new DateTime(1900, 1, 1, 0, 00, 00);
            Paciente Paciente = new Paciente(paciente);
            //Especialista Espl = new Especialista(esp);
        }

        public CitaMedica(int id,DateTime fc, Paciente p, string estado)
        {
            Id = id;
            Fecha = fc;
            Paciente = p;
            Estado = estado;
        }

        public override string ToString()
        {
            return this.Paciente.Nombre + this.Fecha;
        }


    }
}
