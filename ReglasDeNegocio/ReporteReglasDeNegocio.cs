using System;
using System.Collections.Generic;
using Data;
using Entidades;

namespace ReglasDeNegocio
{
    public class ReporteReglasDeNegocio
    {
        private string connectionString;

        public ReporteReglasDeNegocio(string connectionString) { 
            this.connectionString = connectionString;
        }

        public List<Reporte> buscarReporte(String fecha1, String fecha2)
        {
            ReporteData data = new ReporteData(this.connectionString);
            return data.buscarReporte(fecha1, fecha2);
        }//buscarReporte

        //public List<Reporte> buscarReporte()
        //{
        //    ReporteData data = new ReporteData(this.connectionString);
        //    return data.buscarReporte();
        //}//buscarReporte

    }//fin class
}//reglas de negocio
