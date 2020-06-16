using System;
using System.Collections.Generic;
using System.Text;

namespace Diagnos
{
    class Administrador
    {
        private string rut;
        private string nombre;
        private string apellidoP;
        private string apellidoM;
        private DateTime fechaNac;
        private string telefono;
        private string correoElec;

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoP { get => apellidoP; set => apellidoP = value; }
        public string ApellidoM { get => apellidoM; set => apellidoM = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string CorreoElec { get => correoElec; set => correoElec = value; }

        public void init() {
            rut  =  string.Empty;
            nombre  =  string.Empty;
            apellidoP = string.Empty;
            apellidoM  =  string.Empty;
            fechaNac  = new DateTime(1900,01,01,00,00,00);
            telefono  =  string.Empty;
            correoElec = string.Empty;
        }

        public Administrador()
        {

        }
        public Administrador(string rut, string nombre, string apellidoP, string apellidoM,DateTime fechaNac, string telefono, string correoElec)
        {
            Rut  =  rut;
            Nombre  =  nombre;
            ApellidoP  =  apellidoP;
            ApellidoM  =  apellidoM;
            FechaNac  = fechaNac;
            Telefono  =  telefono;
            CorreoElec = correoElec;
        }

        public Administrador(Administrador a)
        {
            Rut  =  a.Rut;
            Nombre = a.Nombre;
            ApellidoP  =  a.ApellidoP;
            ApellidoM  =  a.ApellidoP;
            FechaNac = a.FechaNac;
            Telefono  =  a.Telefono;
            CorreoElec  =  a.CorreoElec;
        }
    }
}
