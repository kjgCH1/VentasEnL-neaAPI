using System;
using System.Collections.Generic;
using System.Text;
using VentasEnLíneaEntidades;

namespace VentasEnLíneaData
{
    internal class SaloneroData
    {

        private string connectionString;

        SaloneroData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearSalonero(VentasEnLíneaEntidades.Salonero salonero)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_salonero @id={salonero.Id}, " +
                $"@nombre='{salonero.Nombre}', " +
                $"@usuario='{salonero.Usuario}'," +
                $"@contraseña={salonero.Contraseña}', " +
                $"@habilitado={salonero.Habilitado}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//crearSalonero

        public void modificarSalonero(VentasEnLíneaEntidades.Salonero salonero)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_salonero @id={salonero.Id}, " +
                $"@nombre='{salonero.Nombre}', " +
                $"@usuario='{salonero.Usuario}'," +
                $"@contraseña={salonero.Contraseña}', " +
                $"@habilitado={salonero.Habilitado}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//modificarSalonero

        public List<VentasEnLíneaEntidades.Salonero> listarSaloneros()
        {
            List<VentasEnLíneaEntidades.Salonero> saloneros = new List<VentasEnLíneaEntidades.Salonero>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_listar_salonero";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VentasEnLíneaEntidades.Salonero salonero = new VentasEnLíneaEntidades.Salonero();
                        salonero.Id = (int)reader["id"];
                        salonero.Nombre = reader["nombre"].ToString();
                        salonero.Usuario = reader["usuario"].ToString();
                        salonero.Contraseña = reader["contraseña"].ToString();
                        salonero.Habilitado = (bool)reader["habilitado"];

                        saloneros.Add(salonero);

                    }
                    connection.Close();

                }
                return saloneros;
            }
        }//listarSaloneros

        public List<VentasEnLíneaEntidades.Salonero> buscarSaloneros(string nombre)
        {
            List<VentasEnLíneaEntidades.Salonero> saloneros = new List<VentasEnLíneaEntidades.Salonero>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_salonero @nombre='{nombre};
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VentasEnLíneaEntidades.Salonero salonero = new VentasEnLíneaEntidades.Salonero();
                        salonero.Id = (int)reader["id"];
                        salonero.Nombre = reader["nombre"].ToString();
                        salonero.Usuario = reader["usuario"].ToString();
                        salonero.Contraseña = reader["contraseña"].ToString();
                        salonero.Habilitado = (bool)reader["habilitado"];

                        saloneros.Add(salonero);

                    }
                    connection.Close();

                }
                return saloneros;
            }
        }//buscarSaloneros


    }
}
