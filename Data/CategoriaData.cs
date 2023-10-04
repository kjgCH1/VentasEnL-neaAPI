using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entidades;

namespace Data
{
    public class CategoriaData
    {

        private string connectionString;

        CategoriaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearCategoria(Categoria categoria)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_categoria @id={categoria.Id}, " +
                $"@nombre='{categoria.Nombre}'";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//crearCategoria

        public void modificarCategoria(Categoria categoria)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_modificar_categoria @id={categoria.Id}, " +
                $"@nombre='{categoria.Nombre}'" ;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//modificarCategoria

        public List<Categoria> listarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_listar_categoria";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.Id = (int)reader["id"];
                        categoria.Nombre = reader["nombre"].ToString();

                        categorias.Add(categoria);

                    }
                    connection.Close();

                }
                return categorias;
            }
        }//listarCategorias

        public List<Categoria> buscarCategorias(string nombre)
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_categoria @nombre='{nombre}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.Id = (int)reader["id"];
                        categoria.Nombre = reader["nombre"].ToString();

                        categorias.Add(categoria);

                    }
                    connection.Close();

                }
                return categorias;
            }
        }//buscarCategoria

    }
}

