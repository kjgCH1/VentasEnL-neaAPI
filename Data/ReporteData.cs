using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data
{
    public  class ReporteData
    {
        private string connectionString;

        ReporteData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Reporte> buscarPedidoCliente(String fecha1, String fecha2)
        {
            var connection = new SqlConnection();
            List<Reporte> reportes = new List<Reporte>();
            string sql = $"exec sp_buscar_reporte @fecha1='{fecha1}', " +
                $"@fecha2='{fecha2}'";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reporte reporte = new Reporte();
                    reporte.Id = (int)reader["id"];
                    reporte.Fecha = reader["fecha"].ToString();
                    reporte.Detalle = reader["detalle"].ToString();
                    reporte.Administrador = (int)reader["administrador"];

                    reportes.Add(reporte);

                }
                connection.Close();
            }
           
            return reportes;
        }
    }
}
