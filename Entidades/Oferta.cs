using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Oferta
    {
        private int id;
        private double precio;
        private int producto;
        private bool habilitado;
        public Oferta() { }

        public Oferta(int id, double precio, int producto, bool habilitado)
        {
            this.id = id;
            this.precio = precio;
            this.producto = producto;
            this.habilitado = habilitado;
        }

        public int Id { get => id; set => id = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Producto { get => producto; set => producto = value; }

        public bool Habilitado { get => habilitado; set => habilitado = value; }
    }
}
