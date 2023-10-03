using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentasEnLínea
{
    internal class Comunidad
    {
        private int id;
        private string nombre;
        private decimal precio;
        private bool habilitado;

        public Comunidad()
        {
        }

        public Comunidad(int id, string nombre, decimal precio, bool habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.habilitado = habilitado;

        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }

    }
}
