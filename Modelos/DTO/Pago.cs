using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDiagnos.Modelos.DTO
{
    class Pago
    {
        private int id;
        private int monto;
        private DateTime fechaPago;

        public int Id { get => id; set => id = value; }
        public int Monto { get => monto; set => monto = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }

        public void init()
        {
            Id = 0;
            Monto = 0;
            FechaPago = new DateTime(1900,01,01,00,00,00);
        }

        public Pago()
        {

        }

        public Pago(int id, int monto, DateTime fecha)
        {
            Id = 0;
            Monto = 0;
            FechaPago = fecha;
        }

        public Pago(Pago p)
        {
            Id = p.Id;
            Monto = p.Monto;
            FechaPago = p.FechaPago;
        }
    }
}
