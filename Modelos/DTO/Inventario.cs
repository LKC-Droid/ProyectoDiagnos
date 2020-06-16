using System;
using System.Collections.Generic;
using System.Text;

namespace Formativa2.Clases
{
    class Inventario
    {
        private int id;
        private string cantidad;
        private Boolean estado;
        private DateTime fechaIngreso;
        private DateTime fechaReposicion;

        public Inventario()
        {

        }

        public Inventario(Inventario i)
        {
            this.id = i.id;
            this.cantidad = i.cantidad;
            this.estado = i.estado;
            this.fechaIngreso = i.fechaIngreso;
            this.fechaReposicion = i.fechaReposicion;
        }

        public Inventario(int id, string cantidad, bool estado, DateTime fechaIngreso, DateTime fechaReposicion)
        {
            this.id = id;
            this.cantidad = cantidad;
            this.estado = estado;
            this.fechaIngreso = fechaIngreso;
            this.fechaReposicion = fechaReposicion;
        }

        public int Id { get => id; set => id = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
        public bool Estado { get => estado; set => estado = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaReposicion { get => fechaReposicion; set => fechaReposicion = value; }
    }
}