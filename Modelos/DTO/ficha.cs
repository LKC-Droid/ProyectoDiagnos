using Diagnos.Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diagnos.Modelos.DTO
{
    public class Ficha
    {
        private int id;
        private string sistemaDeSalud;
        private string alergias;
        private string grupoSanguineo;
        private string enfermedadCronica;
        private string antecedentesPatologicos;
        private string tratamientoActual;
        private string medicamento;
        private string observaciones;

        public int Id { get => id; set => id = value; }
        public string SistemaDeSalud { get => sistemaDeSalud; set => sistemaDeSalud = value; }
        public string Alergias { get => alergias; set => alergias = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
        public string EnfermedadCronica { get => enfermedadCronica; set => enfermedadCronica = value; }
        public string AntecedentesPatologicos { get => antecedentesPatologicos; set => antecedentesPatologicos = value; }
        public string TratamientoActual { get => tratamientoActual; set => tratamientoActual = value; }
        public string Medicamento { get => medicamento; set => medicamento = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }

        public Ficha()
        {

        }

        public Ficha(Ficha f)
        {
            this.Id = f.Id;
            this.SistemaDeSalud = f.SistemaDeSalud;
            this.Alergias = f.Alergias;
            this.GrupoSanguineo = f.GrupoSanguineo;
            this.EnfermedadCronica = f.EnfermedadCronica;
            this.AntecedentesPatologicos = f.AntecedentesPatologicos;
            this.TratamientoActual = f.TratamientoActual;
            this.Medicamento = f.Medicamento;
            this.Observaciones = f.Observaciones;
        }
    }
}
