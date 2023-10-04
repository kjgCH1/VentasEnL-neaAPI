using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Salonero
    {
        private int id;
        private string nombre;
        private string usuario;
        private string contraseña;
        private bool habilitado;
        public Salonero() { }

        public Salonero(int id, string nombre, string usuario, string contraseña, bool habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.habilitado = habilitado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
    }
}
