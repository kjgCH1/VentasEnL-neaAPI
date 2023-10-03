using System;
using System.Collections.Generic;
using System.Text;

namespace VentasEnLíneaData
{
    internal class ComunidadData
    {
        private string connectionString;

        ComunidadData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearComunidad(VentasEnLíneaEntidades.Comunidad comunidad)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_comunidad " +
                $"@id={comunidad.Id}, " +
                $"@nombre='{comunidad.Nombre}', " +
                $"@precio={comunidad.Precio}, ";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//crearComunidad


        public List<VentasEnLíneaEntidades.Comunidad> buscarComunidad(string nombre)
        {
            List<VentasEnLíneaEntidades.Comunidad> comunidades = new List<VentasEnLíneaEntidades.Comunidad>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_comunidad @nombre='{nombre};
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VentasEnLíneaEntidades.Comunidad comunidad = new VentasEnLíneaEntidades.Cliente();
                        comunidad.Id = (int)reader["id"];
                        comunidad.Nombre = reader["nombre"].ToString();
                        comunidad.Precio = (int)reader["precio"];

                        comunidades.Add(comunidad);

                    }
                    connection.Close();

                }
                return comunidades;
            }
        }//buscarComunidad

        public void modificarComunidad(VentasEnLíneaEntidades.Comunidad comunidad)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_modificar_comunidad" +
               $"@id={comunidad.Id}, " +
                $"@nombre='{comunidad.Nombre}', " +
                $"@precio={comunidad.Precio}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//modificarComunidad

        public void habilitarComunidad(VentasEnLíneaEntidades.Comunidad comunidad)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_habilitar_comunidad" +
                $"@nombre='{comunidad.Nombre}', " +
                $"@habilitado={comunidad.Habilitado}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//habilitarComunidad
    }

    public void inhabilitarComunidad(VentasEnLíneaEntidades.Comunidad comunidad)
    {
        var connection = new SqlConnection();
        string sql = $"exec sp_habilitar_comunidad" +
            $"@nombre='{comunidad.Nombre}', " +
            $"@habilitado={comunidad.Habilitado}";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.CommandType = System.Data.CommandType.Text;
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }
    }//inhabilitarComunidad
}
}
//Maria Najera lo hizo