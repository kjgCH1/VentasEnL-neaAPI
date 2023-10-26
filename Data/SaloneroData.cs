using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class SaloneroData
    {

        private string connectionString;

        public SaloneroData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool crearSalonero(Salonero salonero)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_crearSalonero", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@nombre", salonero.Nombre);
                        command.Parameters.AddWithValue("@usuario", salonero.Usuario);
                        command.Parameters.AddWithValue("@contrasena", salonero.Contrasena);
                        command.Parameters.AddWithValue("@habilitado", salonero.Habilitado);

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

        }//crearSalonero

        public bool modificarSalonero(Salonero salonero)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_modificarSalonero", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", salonero.Id);
                        command.Parameters.AddWithValue("@nombre", salonero.Nombre);
                        command.Parameters.AddWithValue("@usuario", salonero.Usuario);
                        command.Parameters.AddWithValue("@contrasena", salonero.Contrasena);
                        command.Parameters.AddWithValue("@habilitado", salonero.Habilitado);
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
        }//modificarSalonero

        public List<Salonero> buscarSalonero(string nombre)
        {
            List<Salonero> saloneros = new List<Salonero>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscarSalonero @nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Salonero salonero = new Salonero();
                        salonero.Id = (int)reader["id"];
                        salonero.Nombre = reader["nombre"].ToString();
                        salonero.Usuario = reader["usuario"].ToString();
                        salonero.Contrasena = reader["contrasena"].ToString();
                        salonero.Habilitado = (bool)reader["habilitado"];

                        saloneros.Add(salonero);

                    }
                    connection.Close();

                }
                return saloneros;
            }
        }//buscarSaloneros

        public Salonero buscarSaloneroId(int id)
        {
            Salonero salonero = new Salonero();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_salonero_ID @id={id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        salonero.Id = (int)reader["id"];
                        salonero.Nombre = reader["nombre"].ToString();
                        salonero.Usuario = reader["usuario"].ToString();
                        salonero.Contrasena = reader["contrasena"].ToString();

                    }
                    connection.Close();

                }
                return salonero;
            }
        }//buscarSaloneroId


    }
}
