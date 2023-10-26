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
        private string imagen;
        private bool habilitado;

        public Producto() { }

        public Producto(int id, string nombre, string descripcion, int categoria, double precio, bool habilitado, string imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.precio = precio;
            this.habilitado = habilitado;
            this.imagen = imagen;

        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Precio { get => precio; set => precio = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
}
