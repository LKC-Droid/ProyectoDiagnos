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
        private string nombreCompleto;
        private string hora;
        //public Especialista esp;
        public DateTime Fecha { get => fecha; set => fecha = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        public int Id { get => id; set => id = value; }
        public string Estado { get => estado; set => estado = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public string Hora { get => hora; set => hora = value; }

        public void Init()
        {
            id = 0;
            Fecha = new DateTime();
            Paciente Paciente = new Paciente(paciente);
            //Especialista Espl = new Especialista(esp);
        }

        public CitaMedica(int id,DateTime fc, Paciente p, string estado)
        {
            Id = id;
            Fecha = fc;
            Paciente = p;
            Estado = estado;
            NombreCompleto = p.NombreCompleto;
            Hora = this.Fecha.ToString("hh:mm tt");

        }

        public override string ToString()
        {
            return this.NombreCompleto + this.Fecha.ToString("hh:mm") + this.Estado;
        }


    }
}
