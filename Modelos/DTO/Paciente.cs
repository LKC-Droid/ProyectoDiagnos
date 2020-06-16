using System;
using System.Collections.Generic;
using System.Text;

namespace Diagnos.Modelos.DTO

{
    class Paciente
    {
        public string _nombre;
        public string apellidoP;
        public string apellidoM;
        private string rut;
        public DateTime fechaNac;
        public string numeroTelefono;
        public string email;
        public string enfCron;


        public string Nombre { get => _nombre; set => _nombre = value; }
        public string ApellidoM { get => apellidoM; set => apellidoM = value; }

        public string ApellidoP { get => apellidoP; set => apellidoP = value; }

        public string NumeroTelefono { get => numeroTelefono; set => numeroTelefono = value; }
        public string Email { get => email; set => email = value; }
        public string EnfCron { get => enfCron; set => enfCron = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Rut { get => rut; set => rut = value; }

        public void Init()
        {
            Nombre = string.Empty;
            ApellidoP = string.Empty;
            ApellidoM = string.Empty;
            Rut = string.Empty;
            NumeroTelefono = string.Empty;
            FechaNac = new DateTime(1900, 1, 1);
            Email = string.Empty;
            EnfCron = string.Empty;
        }


        public Paciente(string _nombre, string apellidoP, string apellidoM, string rut)
        {
            Nombre = _nombre;
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
            Rut = rut;
        }

        public Paciente(Paciente p)
        {
            Nombre = p.Nombre;
            ApellidoP = p.ApellidoP;
            ApellidoM = p.ApellidoM;
            Rut = p.Rut;
        }

    }
}
