using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Data
{
    public class AdministradorData
    {
        private string connectionString;

        AdministradorData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Administrador iniciarSession(string usuario, string contraseña)
        {
            Administrador administrador = new Administrador();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_iniciar_session_administrador @usuario='{usuario}', " +
                $"@contraseña='{contraseña}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    administrador.Id = (int)reader["id"];
                    administrador.Nombre = reader["nombre"].ToString();
                    administrador.Usuario = reader["usuario"].ToString();
                    administrador.Contraseña = reader["contraseña"].ToString();


                }
                return administrador;
            }
        }
    }
}
