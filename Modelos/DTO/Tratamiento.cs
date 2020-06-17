using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDiagnos.Modelos.DTO
{
    class Tratamiento
    {
        private int id;
        private string diagnostico;
        private int valor;

        public int Id { get => id; set => id = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public int Valor { get => valor; set => valor = value; }

        public void init()
        {
            id = 0;
            diagnostico = string.Empty;
            valor = 0;
        }

        public Tratamiento()
        {

        }

        public Tratamiento(int id, string diagno,int valor)
        {
            Id = id;
            Diagnostico = diagno;
            Valor = valor;
        }

        public Tratamiento(Tratamiento t)
        {
            Id = t.Id;
            Diagnostico = t.Diagnostico;
            Valor = t.Valor;
        }
    }
}
