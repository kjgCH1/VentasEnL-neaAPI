using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entidades;

namespace ReglasDeNegocio
{
    public class ProductoReglasDeNegocio
    {
        private string connectionString;

         public  ProductoReglasDeNegocio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool crearProducto(Producto producto) {
            ProductoData data = new ProductoData(this.connectionString);
            return data.crearProducto(producto);
        }

        public List<Producto> buscarProducto(String nombre) {
            ProductoData data = new ProductoData(this.connectionString);   
            return data.buscarProducto(nombre);
        }

        public List<Producto> buscarProductoCategoria(int catgeoria)
        {
            ProductoData data = new ProductoData(this.connectionString);
            return data.buscarProductoCategoria(catgeoria);
        }
    }
}
