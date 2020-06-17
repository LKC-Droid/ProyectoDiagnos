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
        private string rutpaciente;
        private string estado;
        private string nombreCompleto;
        private string hora;
        private string rutesp;
        private string rutadm;
        public DateTime Fecha { get => fecha; set => fecha = value; }
        
        public int Id { get => id; set => id = value; }
        public string Estado { get => estado; set => estado = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public string Hora { get => hora; set => hora = value; }
        public string Rutesp { get => rutesp; set => rutesp = value; }
        public string Rutadm { get => rutadm; set => rutadm = value; }
        public string Rutpaciente { get => rutpaciente; set => rutpaciente = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }

        public void Init()
        {
            id = 0;
            Fecha = new DateTime();
            
            //Especialista Espl = new Especialista(esp);
        }

        public CitaMedica(int id,DateTime fc, string rp, string re,string ra,Paciente p)
        {
            Id = id;
            Fecha = fc;
            Rutpaciente = rp;
            Rutadm = ra;
            Rutesp = rutesp;
            NombreCompleto = p.NombreCompleto;
            Hora = this.Fecha.ToString("hh:mm tt");

        }

        public override string ToString()
        {
            return this.NombreCompleto + this.Fecha.ToString("hh:mm") + this.Estado;
        }


    }
}
