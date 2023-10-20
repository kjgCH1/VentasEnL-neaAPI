using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{

        public class Categoria
        {
            private int id;
            private string nombre;
            private bool habilitado;


            public Categoria() { 
                this.id = 0;
                this.nombre = null;
                this.habilitado = false;
            }

            public Categoria(int id, string nombre, bool habilitado)
            {
                this.id = id;
                this.nombre = nombre;
                this.habilitado = habilitado;
            }

            public int Id { get => id; set => id = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public bool Habilitado { get => habilitado; set => habilitado = value; }

        }

    }

