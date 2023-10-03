using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentasEnLínea
{
    internal class Direccion
    {
        private int id;
        private string detalle;
        private int comunidad;
        private int cliente;
        private bool habilitado;

        public Direccion()
        {
        }

        public Direccion(int id, string detalle, int comunidad, int cliente, bool habilitado)
        {
            this.id = id;
            this.detalle = detalle;
            this.comunidad = comunidad;
            this.cliente = cliente;
            this.habilitado = habilitado;

        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => detalle; set => detalle = value; }
        public int Comunidad { get => comunidad; set => comunidad = value; }
        public int Cliente { get => cliente; set => cliente = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }

    }
}
