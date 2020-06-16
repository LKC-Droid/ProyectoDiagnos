using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDiagnos.Modelos.DTO
{
    class PresupuestoPago
    {
        private Presupuesto presu;
        private Pago pago;

        public PresupuestoPago()
        {

        }

        public PresupuestoPago(Presupuesto pre, Pago pa)
        {
            Presu = pre;
            pago = pa;
        }

        public PresupuestoPago(PresupuestoPago pre)
        {
            Presu = pre.Presu;
            Pago = pre.Pago;
        }

        internal Presupuesto Presu { get => presu; set => presu = value; }
        internal Pago Pago { get => pago; set => pago = value; }
    }
}
