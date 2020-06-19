using System;
using System.Collections.Generic;
using System.Text;

namespace Diagnos.Modelos.DTO
{
    class Especialista
    {
        private string rut;
        private string nombre;
        private string apellido;
        private DateTime fechaNac;
        private string especialidad;
        private string correo;
        private int telefono;

        public Especialista(){}

        public Especialista(Especialista e)
        {
            this.Rut = e.rut;
            this.Nombre = e.nombre;
            this.Apellido = e.apellido;
            this.FechaNac = e.fechaNac;
            this.Especialidad = e.especialidad;
            this.Correo = e.correo;
            this.Telefono = e.telefono;
        }

        public Especialista(string rut, string nombre, string apellido, DateTime fechaNac, string especialidad, string correo, int telefono)
        {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNac = fechaNac;
            this.Especialidad = especialidad;
            this.Correo = correo;
            this.Telefono = telefono;
        }


        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Telefono { get => telefono; set => telefono = value; }
    }
}