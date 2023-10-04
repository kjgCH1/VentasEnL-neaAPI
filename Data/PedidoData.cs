
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Data
{
    public class PedidoData
    {
        private string connectionString;

        PedidoData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void realizarPedido(Pedido pedido) {
           
            var connection = new SqlConnection();
            string sql = $"exec sp_realizar_pedido" +
                $"@fecha='{pedido.Fecha}', " +
                $"@cliente={pedido.Cliente}," +
                $"@direccion={pedido.Direccion}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                pedido.Id = (int)reader["id"];
                connection.Close();
            }

            List<int> productos = pedido.Productos;

            foreach (int producto in productos)
            {
                connection = new SqlConnection();
                sql = $"exec sp_producto_pedido" +
                    $"@producto={producto}," +
                    $"@pedido={pedido.Id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }

            List<int> ofertas = pedido.Ofertas;

            foreach (int oferta in ofertas)
            {
                connection = new SqlConnection();
                sql = $"exec sp_oferta_pedido" +
                    $"@oferta={oferta}," +
                    $"@pedido={pedido.Id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void agregarSalonero(int idPedido, int idSalonero) {
            var connection = new SqlConnection();
            string sql = $"exec sp_salonero_pedido" +
                $"@pedido={idPedido}, " +
                $"@salonero={idSalonero}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        public List<Pedido> buscarPedidoAministrador(String fecha1, String fecha2) {
            var connection = new SqlConnection();
            List<Pedido> pedidos = new List<Pedido>();
            string sql = $"exec sp_buscar_pedido @fecha1='{fecha1}', " +
                $"@fecha2='{fecha2}'";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = (int)reader["id"];
                    pedido.Fecha = reader["fecha"].ToString();
                    pedido.Direccion = (int)reader["direccion"];
                    pedido.Salonero = (int)reader["salonero"];

                    pedidos.Add(pedido);

                }
                connection.Close();
            }
            foreach (var pedido in pedidos) { 
                buscarOfertaPedido(pedido);
                buscarProductoPedido(pedido);
            }

            return pedidos;
        }

        private Pedido buscarProductoPedido(Pedido pedido) {
            var connection = new SqlConnection();
            string sql = $"exec sp_buscar_pedido_productos @idPedido='{pedido.Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    pedido.Productos.Add((int)reader["idProducto"]);
                }
             }
            return pedido;
        }

        private Pedido buscarOfertaPedido(Pedido pedido)
        {
            var connection = new SqlConnection();
            string sql = $"exec sp_buscar_pedido_productos @idPedido='{pedido.Id}";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pedido.Ofertas.Add((int)reader["idProducto"]);
                }
            }
            return pedido;
        }

        public List<Pedido> buscarPedidoCliente(int idCliente, String fecha1, String fecha2) {
            var connection = new SqlConnection();
            List<Pedido> pedidos = new List<Pedido>();
            string sql = $"exec sp_buscar_pedido_cliente @cliente={idCliente} @fecha1='{fecha1}', " +
                $"@fecha2='{fecha2}'";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = (int)reader["id"];
                    pedido.Fecha = reader["fecha"].ToString();
                    pedido.Direccion = (int)reader["direccion"];
                    pedido.Salonero = (int)reader["salonero"];

                    pedidos.Add(pedido);

                }
                connection.Close();
            }
            foreach (var pedido in pedidos)
            {
                buscarOfertaPedido(pedido);
                buscarProductoPedido(pedido);
            }

            return pedidos;
        }
    }
}
