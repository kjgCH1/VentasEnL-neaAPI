using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Data
{
    internal class ClienteData
    {
        private string connectionString;

        ClienteData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearCliente(Cliente cliente)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_cliente " +
                $"@id={cliente.Id}, " +
                $"@cedula={cliente.Cedula}, " +
                $"@nombre='{cliente.Nombre}', " +
                $"@telefono='{cliente.Telefono}', " +
                $"@celular='{cliente.Celular}', " +
                $"@usuario='{cliente.Usuario}'," +
                $"@contrasena={cliente.Contrasena}";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//crearCliente

        public void modificarCliente(Cliente cliente)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_modificar_cliente" +
               $"@id={cliente.Id}, " +
                $"@cedula={cliente.Cedula}, " +
                $"@nombre='{cliente.Nombre}', " +
                $"@telefono='{cliente.Telefono}', " +
                $"@celular='{cliente.Celular}', " +
                $"@usuario='{cliente.Usuario}'," +
                $"@contrasena={cliente.Contrasena}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//modificarCliente


        public List<Cliente> buscarCliente(string cedula)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_cliente @cedula='{cedula}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = (int)reader["id"];
                        cliente.Cedula = (int)reader["cedula"];
                        cliente.Nombre = reader["nombre"].ToString();
                        cliente.Telefono = reader["telefono"].ToString();
                        cliente.Celular = reader["celular"].ToString();
                        cliente.Usuario = reader["usuario"].ToString();
                        cliente.Contrasena = reader["contrasena"].ToString();

                        clientes.Add(cliente);

                    }
                    connection.Close();

                }
                return clientes;
            }
        }//buscarClientes

        public List<Cliente> listarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_listar_cliente";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = (int)reader["id"];
                        cliente.Cedula = (int)reader["cedula"];
                        cliente.Nombre = reader["nombre"].ToString();
                        cliente.Telefono = reader["telefono"].ToString();
                        cliente.Celular = reader["celular"].ToString();
                        cliente.Usuario = reader["usuario"].ToString();
                        cliente.Contrasena = reader["contrasena"].ToString();

                        clientes.Add(cliente);

                    }
                    connection.Close();

                }
                return clientes;
            }
        }//listarClientes

        public void habilitarCliente(Cliente cliente)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_habilitar_cliente" +
               $"@cedula={cliente.Cedula}, " +
                $"@habilitado={cliente.Habilitado}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//habilitarCliente
    }

}
