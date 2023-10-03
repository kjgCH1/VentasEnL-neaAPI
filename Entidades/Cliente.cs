using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentasEnLínea
{
    internal class Cliente
    {
        private int id;
        private int cedula;
        private string nombre;
        private string telefono;
        private string celular;
        private string usuario;
        private string contrasena;
        private bool habilitado;

        public Cliente()
        {
        }

        public Cliente(int id, int cedula, string nombre, string telefono, string celular, string usuario, string contrasena, bool habilitado)
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.telefono = telefono;
            this.celular = celular;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.habilitado = habilitado;

        }

        public int Id{ get => id; set => id = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }

    }
}
