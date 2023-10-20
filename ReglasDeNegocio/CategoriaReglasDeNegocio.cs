using Data;
using Entidades;
using System.Collections.Generic;

namespace ReglasDeNegocio
{
    public class CategoriaReglasDeNegocio
    {
        private string connectionString;

        public CategoriaReglasDeNegocio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Categoria> buscarCategoria(string nombre) { 
            CategoriaData data = new CategoriaData(this.connectionString);
            return data.buscarCategoria(nombre);
        }

        public Categoria buscarCategoriaId(int id)
        {
            CategoriaData data = new CategoriaData(this.connectionString);
            return data.buscarCategoriaId(id);
        }

        public bool modificarCategoria(Categoria categoria) 
        {
            CategoriaData data = new CategoriaData(this.connectionString);
            return data.modificarCategoria(categoria);
        }

        public bool crearCategoria(Categoria categoria) { 
            CategoriaData data = new CategoriaData(this.connectionString);
            return data.crearCategoria(categoria);
        }
    }
}
