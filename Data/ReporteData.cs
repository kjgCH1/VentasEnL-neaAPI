using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public  class ReporteData
    {
        private string connectionString;

        public ReporteData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Reporte> buscarReporte(string fecha1, string fecha2)
        {
            //var connection = new SqlConnection(connectionString); // Reemplaza "tu_cadena_de_conexion" con la cadena de conexión real.
            List<Reporte> reportes = new List<Reporte>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"exec sp_buscarReporte @fechaInicio='{fecha1}', @fechaFin='{fecha2}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    //command.Parameters.AddWithValue("@fechaInicio", fecha1);
                    //command.Parameters.AddWithValue("@fechaFin", fecha2);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Reporte reporte = new Reporte();
                            reporte.Id = (int)reader["id"];
                            reporte.Fecha = reader["fecha"].ToString();
                            reporte.Detalle = reader["detalle"].ToString();
                            //reporte.Administrador = (int)reader["administrador"];

                            reportes.Add(reporte);
                        }
                    connection.Close();
                }
                return reportes;
            }
        }


        //public List<Reporte> buscarReporte(String fecha1, String fecha2)
        //{
        //    var connection = new SqlConnection();
        //    List<Reporte> reportes = new List<Reporte>();
        //    string sql = $"exec sp_buscarReporte @fechaInicio='{fecha1}', @fechaFin='{fecha2}'";
        //    //string sql = "exec sp_buscarReporte @fechaInicio, @fechaFin";
        //    //string sql = $"exec sp_buscarReporte @fechaInicio='{fecha1}' & @fechaFin='{fecha2}'";


        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        command.CommandType = System.Data.CommandType.Text;
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Reporte reporte = new Reporte();
        //            reporte.Id = (int)reader["id"];
        //            reporte.Fecha = reader["fecha"].ToString();
        //            reporte.Detalle = reader["detalle"].ToString();
        //            reporte.Administrador = (int)reader["administrador"];

        //            reportes.Add(reporte);

        //        }
        //        connection.Close();
        //    }

        //    return reportes;
        //}//buscarReporte

        //public List<Reporte> buscarReporte()
        //{
        //    var connection = new SqlConnection();
        //    List<Reporte> reportes = new List<Reporte>();
        //    string sql = $"exec sp_buscarReporte";
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        command.CommandType = System.Data.CommandType.Text;
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Reporte reporte = new Reporte();
        //            reporte.Id = (int)reader["id"];
        //            reporte.Fecha = reader["fecha"].ToString();
        //            reporte.Detalle = reader["detalle"].ToString();
        //            reporte.Administrador = (int)reader["administrador"];

        //            reportes.Add(reporte);

        //        }
        //        connection.Close();
        //    }
        //    return reportes;
        //}//buscarReporte

    }//fin clase
}
