using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Data
{
    internal class DireccionData
    {
        private string connectionString;

        DireccionData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void crearDireccion(Direccion direccion)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_direccion " +
                $"@id={direccion.Id}, " +
                $"@detalle='{direccion.Detalle}', " +
                $"@comunidad={direccion.Comunidad}, " +
                $"@cliente={direccion.Cliente}, ";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//crearDireccion

        public void modificarDireccion(Direccion direccion)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_modificar_direccion" +
               $"@id={direccion.Id}, " +
                $"@detalle='{direccion.Detalle}', " +
                $"@comunidad='{direccion.Comunidad}', " +
                $"@cliente={direccion.Cliente}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//modificarDireccion


        public List<Direccion> buscarDireccion(string cedula)
        {
            List<Direccion> direcciones = new List<Direccion>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_direccion @cedula='{cedula}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Direccion direccion = new Direccion();
                        direccion.Id = (int)reader["id"];
                        direccion.Detalle = reader["detalle"].ToString();
                        direccion.Comunidad = (int)reader["comunidad"];
                        direccion.Cliente = (int)reader["cliente"];

                        direcciones.Add(direccion);

                    }
                    connection.Close();

                }
                return direcciones;
            }
        }//buscarDireccion

        public List<Direccion> listarDirecciones()
        {
            List<Direccion> direcciones = new List<Direccion>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_listar_direccion";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Direccion direccion = new Direccion();
                        direccion.Id = (int)reader["id"];
                        direccion.Detalle = reader["detalle"].ToString();
                        direccion.Comunidad = (int)reader["comunidad"];
                        direccion.Cliente = (int)reader["cliente"];

                        direcciones.Add(direccion);

                    }
                    connection.Close();

                }
                return direcciones;
            }
        }//listarDirecciones


        public void habilitarDireccion(Direccion direccion)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_habilitar_direccion" +
               $"@id={direccion.Id}, " +
                $"@habilitado={direccion.Habilitado}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//habilitarDireccion
    }

}
