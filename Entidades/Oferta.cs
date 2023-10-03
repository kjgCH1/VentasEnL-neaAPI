using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentasEnLínea
{
    public class Oferta
    {
        private int id;
        private double precio;
        private int producto;

        public Oferta() { }

        public Oferta(int id, double precio, int producto)
        {
            this.id = id;
            this.precio = precio;
            this.producto = producto;
        }

        public int Id { get => id; set => id = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Producto { get => producto; set => producto = value; }
    }
}
