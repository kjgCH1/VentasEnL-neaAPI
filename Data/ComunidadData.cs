
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
namespace Data
{
    internal class ComunidadData
    {
        private string connectionString;

        ComunidadData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearComunidad(Comunidad comunidad)
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
                        comunidad.Precio = (int)reader["precio"];

                        comunidades.Add(comunidad);

                    }
                    connection.Close();

                }
                return comunidades;
            }
        }//buscarComunidad

        public void modificarComunidad(Comunidad comunidad)
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

    }

}
//Maria Najera lo hizo