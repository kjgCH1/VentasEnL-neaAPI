using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;

namespace Data
{
    public class CategoriaData
    {

        private string connectionString;

        public CategoriaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool crearCategoria(Categoria categoria)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_crear_categoria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@nombre", categoria.Nombre);

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

        }//crearComunidad


        public bool modificarCategoria(Categoria categoria)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_modificar_categoria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", categoria.Id);
                        command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                        command.Parameters.AddWithValue("@Habilitado", categoria.Habilitado);
                        int rowsAffected = command.ExecuteNonQuery();

                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                // Manejo de errores
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }//modificarCategoria

        public List<Categoria> buscarCategoria(string nombre)
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_categoria @nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.Id = (int)reader["id"];
                        categoria.Nombre = reader["nombre"].ToString();
                        categoria.Habilitado = (bool)reader["habilitado"];

                        categorias.Add(categoria);

                    }
                    connection.Close();

                }
                return categorias;
            }
        }//buscarComunidad

        public Categoria buscarCategoriaId(int id)
        {
            Categoria categoria = new Categoria();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_categoria_ID @id={id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        categoria.Id = (int)reader["id"];
                        categoria.Nombre = reader["nombre"].ToString();
                        categoria.Habilitado = (bool)reader["habilitado"];

                    }
                    connection.Close();

                }
                return categoria;
            }
        }//buscarComunidadId

        public bool habilitarCategoria(Categoria categoria)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_habilitar_categoria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", categoria.Id);
                        command.Parameters.AddWithValue("@habilitado", categoria.Habilitado);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // La modificación se realizó correctamente
                            return true;
                        }
                        else
                        {
                            // La categoría no se encontró o no se modificó
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }//habilitarCategoria

    }
}

