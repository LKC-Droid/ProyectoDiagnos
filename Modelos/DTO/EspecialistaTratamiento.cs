using Diagnos.Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDiagnos.Modelos.DTO
{
    class EspecialistaTratamiento
    {
        private Tratamiento tratamiento;
        private Especialista especialista;

        internal Tratamiento Tratamiento { get => tratamiento; set => tratamiento = value; }
        internal Especialista Especialista { get => especialista; set => especialista = value; }

        public EspecialistaTratamiento()
        {

        }

        public EspecialistaTratamiento(Tratamiento t, Especialista e)
        {
            Tratamiento = t;
            Especialista = e;
        }

        public EspecialistaTratamiento(EspecialistaTratamiento et)
        {
            Tratamiento = et.Tratamiento;
            Especialista = et.Especialista;
        }
    }
}
