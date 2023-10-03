using System;
using System.Collections.Generic;
using System.Text;

namespace VentasEnLíneaEntidades
{
    public class Administrador
    {
        private int id;
        private string nombre;
        private string usuario;
        private string contraseña;

        public Administrador() { }

        public Administrador(int id, string nombre, string usuario, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.usuario = usuario;
            this.contraseña = contraseña;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
    }
}
