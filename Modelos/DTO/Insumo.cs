using System;

namespace Diagnos
{
    public class Insumo
    {
        private int id;
        private string nombre;
        private string descripcion;
        private DateTime caducidad;
        private string tipo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Caducidad { get => caducidad; set => caducidad = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public void init()
        {
            Nombre = string.Empty;
            Id = 0;
            Descripcion = string.Empty;
            Caducidad = new DateTime(1900,1,1,0,00,00);
            Tipo = string.Empty;
        }

        public Insumo()
        {

        }

        public Insumo(int id, string nombre, string descripcion, DateTime caducidad, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Caducidad = caducidad;
            Tipo = tipo;
        }

        public Insumo(string nombre, string descripcion, DateTime caducidad, string tipo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Caducidad = caducidad;
            Tipo = tipo;
        }

        public Insumo(Insumo i)
        {
            Id = i.Id;
            nombre = i.nombre;
            descripcion = i.descripcion;
            caducidad = i.caducidad;
            tipo = i.tipo;
        }
    }
}
