using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using VentasEnLíneaEntidades;

namespace VentasEnLíneaData
{
    internal class ProductoData
    {
        private string connectionString;

        ProductoData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearProducto(VentasEnLíneaEntidades.Producto producto)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_producto @id={producto.Id}, " +
                $"@nombre='{producto.Nombre}', " +
                $"@descripcion='{producto.Descripcion}'," +
                $"@categoria={producto.Categoria}" +
                $"@habilitado={producto.Habilitado}" +
                $"@precio={producto.Precio}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        public void modificarProducto(VentasEnLíneaEntidades.Producto producto)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_modificar_producto @id={producto.Id}, " +
                $"@nombre='{producto.Nombre}', " +
                $"@descripcion='{producto.Descripcion}'," +
                $"@categoria={producto.Categoria}" +
                 $"@habilitado={producto.Habilitado}" +
                $"@precio={producto.Precio}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }
        public List<VentasEnLíneaEntidades.Producto> listarProductos()
        {
            List<VentasEnLíneaEntidades.Producto> productos = new List<VentasEnLíneaEntidades.Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_listar_producto";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VentasEnLíneaEntidades.Producto producto = new VentasEnLíneaEntidades.Producto();
                        producto.Id = (int)reader["id"];
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Categoria = (int)reader["categoria"];
                        producto.Habilitado = (bool)reader["habilitado"];
                        producto.Precio = (double)reader["precio"];

                        productos.Add(producto);

                    }
                    connection.Close();

                }
                return productos;
            }
        }
        public List<VentasEnLíneaEntidades.Producto> buscarProductos(string nombre, int categoria)
        {
            List<VentasEnLíneaEntidades.Producto> productos = new List<VentasEnLíneaEntidades.Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_producto @nombre='{nombre}', " +
                $"@categoria='{categoria}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VentasEnLíneaEntidades.Producto producto = new VentasEnLíneaEntidades.Producto();
                        producto.Id = (int)reader["id"];
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Categoria = (int)reader["categoria"];
                        producto.Habilitado = (bool)reader["habilitado"];
                        producto.Precio = (double)reader["precio"];

                        productos.Add(producto);

                    }
                    connection.Close();

                }
                return productos;
            }
        }
    }
}
