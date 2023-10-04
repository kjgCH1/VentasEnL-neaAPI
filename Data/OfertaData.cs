using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entidades;

namespace Data
{
    internal class OfertaData
    {

        private string connectionString;

        OfertaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearOferta(Oferta oferta)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_oferta @id={oferta.Id}, " +
                 $"@precio='{oferta.Precio}', " +
                 $"@producto={oferta.Producto}', " +
                 $"@habilitado={oferta.Habilitado}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//crearOferta

        public void modificarOferta(Oferta oferta)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_modificar_oferta @id={oferta.Id}, " +
                $"@precio='{oferta.Precio}', " +
                $"@producto='{oferta.Producto}', " +
                $"@habilitado={oferta.Habilitado}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//modificarOferta

        public List<Oferta> listarOfertas()
        {
            List<Oferta> ofertas = new List<Oferta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_listar_oferta";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Oferta oferta = new Oferta();
                        oferta.Id = (int)reader["id"];
                        oferta.Precio = (double)reader["precio"];
                        oferta.Producto = (int)reader["producto"];
                        oferta.Habilitado = (bool)reader["habilitado"];

                        ofertas.Add(oferta);

                    }
                    connection.Close();

                }
                return ofertas;
            }

        }//listarOfertas

        public List<Oferta> buscarOfertas(string nombre)
        {
            List<Oferta> ofertas = new List<Oferta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_oferta @nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Oferta oferta = new Oferta();
                        oferta.Id = (int)reader["id"];
                        oferta.Precio = (double)reader["precio"];
                        oferta.Producto = (int)reader["producto"];
                        oferta.Habilitado = (bool)reader["habilitado"];

                        ofertas.Add(oferta);

                    }
                    connection.Close();

                }
                return ofertas;
            }
        }//buscarOferta

    }
}
