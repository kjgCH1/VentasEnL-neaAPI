using System.Collections.Generic;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Data
{
    public class ProductoData
    {
        private string connectionString;

        public ProductoData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool crearProducto(Producto producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_crearProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Categoria", producto.Categoria);
                        command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@Imagen", producto.Imagen);
                        command.Parameters.AddWithValue("@habilitado", producto.Habilitado);

                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // El número 2627 es específico para violación de restricción única.
                {
                    // Aquí puedes manejar el error como desees, por ejemplo, mostrar un mensaje al usuario.
                    Console.WriteLine("Ya existe un registro con ese nombre.");
                    return false;
                }
                else
                {
                    // Otro manejo de errores si no es una violación de restricción única.
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }

        }

        public List<Producto> buscarProducto(string nombre)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"exec sp_buscarProducto @Nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = (int)reader["id"];
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Habilitado = (bool)reader["habilitado"];
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Categoria = (int)reader["categoria"];
                        producto.Precio = (decimal)reader["precio"];
                        producto.Imagen = reader["imagen"].ToString();
                        productos.Add(producto);

                    }
                    connection.Close();

                }
                return productos;
            }
        }
        public List<Producto> buscarProductoCategoria(int categoria)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"exec sp_bucarProductoCategoria @categoria={categoria}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = (int)reader["id"];
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Habilitado = (bool)reader["habilitado"];
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Categoria = (int)reader["categoria"];
                        producto.Precio = (decimal)reader["precio"];
                        producto.Imagen = reader["imagen"].ToString();
                        productos.Add(producto);

                    }
                    connection.Close();

                }
                return productos;
            }
        }
    }
}
