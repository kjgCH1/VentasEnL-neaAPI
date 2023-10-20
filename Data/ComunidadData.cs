
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;
namespace Data
{
    public class ComunidadData
    {
        private string connectionString;

        public ComunidadData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool crearComunidad(Comunidad comunidad)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_crear_comunidad", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@nombre", comunidad.Nombre);
                        command.Parameters.AddWithValue("@precio", comunidad.Precio);

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

        public List<Comunidad> buscarComunidad(string nombre)
        {
            List<Comunidad> comunidades = new List<Comunidad>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_comunidad @nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Comunidad comunidad = new Comunidad();
                        comunidad.Id = (int)reader["id"];
                        comunidad.Nombre = reader["nombre"].ToString();
                        comunidad.Precio = (decimal)reader["precio"];

                        comunidades.Add(comunidad);

                    }
                    connection.Close();

                }
                return comunidades;
            }
        }//buscarComunidad

        public bool modificarComunidad(Comunidad comunidad)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_modificar_comunidad", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@NuevoNombre", comunidad.Nombre);
                        command.Parameters.AddWithValue("@NuevoPrecio", comunidad.Precio);
                        command.Parameters.AddWithValue("@ComunidadID", comunidad.Id);
                        // Ejecutar el procedimiento almacenado
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                    // Otro manejo de errores si no es una violación de restricción única.
                    Console.WriteLine("Error: " + ex.Message);
                    return false;       
            }
        }//modificarComunidad

        public Comunidad buscarComunidadId(int id)
        {
            Comunidad comunidad = new Comunidad();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_comunidad_ID @id={id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        comunidad.Id = (int)reader["id"];
                        comunidad.Nombre = reader["nombre"].ToString();
                        comunidad.Precio = (decimal)reader["precio"];



                    }
                    connection.Close();

                }
                return comunidad;
            }
        }

    }
}
//Maria Najera lo hizo