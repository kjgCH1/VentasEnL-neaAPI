using System;
using System.Collections.Generic;
using System.Text;
using VentasEnLíneaEntidades;

namespace VentasEnLíneaData
{
    internal class CategoriaData
    {

        private string connectionString;

        CategoriaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void crearCategoria(VentasEnLíneaEntidades.Categoria categoria)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_crear_categoria @id={categoria.Id}, " +
                $"@nombre='{categoria.Nombre}', " +
                $"@habilitado={categoria.Habilitado}" +
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//crearCategoria

        public void modificarCategoria(VentasEnLíneaEntidades.Categoria categoria)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_modificar_categoria @id={categoria.Id}, " +
                $"@nombre='{categoria.Nombre}', " +
                $"@habilitado={categoria.Habilitado}" ;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }//modificarCategoria

        public List<VentasEnLíneaEntidades.Categoria> listarCategorias()
        {
            List<VentasEnLíneaEntidades.Categoria> categorias = new List<VentasEnLíneaEntidades.Categoria>();

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
                        VentasEnLíneaEntidades.Categoria categoria = new VentasEnLíneaEntidades.Categoria();
                        categoria.Id = (int)reader["id"];
                        categoria.Nombre = reader["nombre"].ToString();
                        categoria.Habilitado = (bool)reader["habilitado"];

                        categorias.Add(categoria);

                    }
                    connection.Close();

                }
                return categorias;
            }
        }//listarCategorias

        public List<VentasEnLíneaEntidades.Categoria> buscarCategorias(string nombre)
        {
            List<VentasEnLíneaEntidades.Categoria> categorias = new List<VentasEnLíneaEntidades.Categoria>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = $"exec sp_buscar_categoria @nombre='{nombre};
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VentasEnLíneaEntidades.Categoria categoria = new VentasEnLíneaEntidades.Categoria();
                        categoria.Id = (int)reader["id"];
                        categoria.Nombre = reader["nombre"].ToString();
                        categoria.Habilitado = (bool)reader["habilitado"];

                        categorias.Add(categoria);

                    }
                    connection.Close();

                }
                return categorias;
            }
        }//buscarCategoria

    }
}

