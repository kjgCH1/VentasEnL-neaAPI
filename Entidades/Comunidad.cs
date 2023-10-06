using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Comunidad
    {
        private int id;
        private string nombre;
        private decimal precio;

        public Comunidad()
        {
        }

        public Comunidad(int id, string nombre, decimal precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
           
        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }

    }
}
