using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Entidades
{
    public class Salonero
    {
        private int id;
        private string nombre;
        private string usuario;
        private string contrasena;
        private bool habilitado;
        public Salonero() { }

        public Salonero(int id, string nombre, string usuario, string contrasena, bool habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.habilitado = habilitado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
    }
}
