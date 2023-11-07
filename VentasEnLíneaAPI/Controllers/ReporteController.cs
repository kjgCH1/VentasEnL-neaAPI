using Microsoft.AspNetCore.Mvc;
using ReglasDeNegocio;
using Entidades;
using Newtonsoft.Json;

namespace VentasEnLíneaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]//Ensablado de clase

    public class ReporteController : ControllerBase
    {
       
        [HttpGet]
        public string BuscarReporte()
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            ReporteReglasDeNegocio reglasDeNegocio = new ReporteReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarReporte("1999-10-01", "2045-01-01"));
        }//BuscarReporte

        [HttpGet("buscarReporte")]
        public string BuscarReporte(string parametroBusqueda1, string parametroBusqueda2)
        {
            if (string.IsNullOrEmpty(parametroBusqueda1) || string.IsNullOrEmpty(parametroBusqueda2))
            {
                return "El parámetro de búsqueda no puede estar vacío.";
            }
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            ReporteReglasDeNegocio reglasDeNegocio = new ReporteReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarReporte(parametroBusqueda1, parametroBusqueda2));
        }//BuscarReporteFecha

    }//fin clase
}
