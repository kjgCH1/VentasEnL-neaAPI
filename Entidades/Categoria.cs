using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentasEnLínea
{
    public class Categoria
    {
        private int id;
        private string nombre;

        public Categoria() { }

        public Categoria(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

    }
}
