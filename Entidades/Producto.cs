using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int categoria;
        private double precio;

        public Producto() { }

        public Producto(int id, string nombre, string descripcion, int categoria, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.precio = precio;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}
