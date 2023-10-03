using System;
using System.Collections.Generic;
using System.Text;
using VentasEnLíneaEntidades;

namespace VentasEnLíneaData
{
    internal class OfertaData
    {

        private string connectionString;

        OfertaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearOferta(VentasEnLíneaEntidades.Oferta oferta)
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

        public void modificarOferta(VentasEnLíneaEntidades.Oferta oferta)
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

        public List<VentasEnLíneaEntidades.Oferta> listarOfertas()
        {
            List<VentasEnLíneaEntidades.Oferta> ofertas = new List<VentasEnLíneaEntidades.Oferta>();

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
                        VentasEnLíneaEntidades.Oferta oferta = new VentasEnLíneaEntidades.Oferta();
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

        public List<VentasEnLíneaEntidades.Oferta> buscarOfertas(string nombre)
        {
            List<VentasEnLíneaEntidades.Oferta> ofertas = new List<VentasEnLíneaEntidades.Oferta>();

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
                        VentasEnLíneaEntidades.Oferta oferta = new VentasEnLíneaEntidades.Oferta();
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
