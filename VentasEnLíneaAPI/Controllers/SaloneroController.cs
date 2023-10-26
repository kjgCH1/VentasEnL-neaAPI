using Microsoft.AspNetCore.Mvc;
using Entidades;
using ReglasDeNegocio;
using Newtonsoft.Json;

namespace VentasEnLíneaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//Ensablado de clase
    public class SaloneroController : ControllerBase
    {
        [HttpGet]
        public string BuscarSalonero()
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            SaloneroReglasDeNegocio reglasDeNegocio = new SaloneroReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarSalonero(""));
        }

        [HttpGet("buscarSalonero")]
        public string BuscarSalonero(string parametroBusqueda)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            SaloneroReglasDeNegocio reglasDeNegocio = new SaloneroReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarSalonero(parametroBusqueda));
        }

        [HttpGet("buscarSaloneroId")]
        public string BuscarSaloneroId(int id)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            SaloneroReglasDeNegocio reglasDeNegocio = new SaloneroReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarSaloneroId(id));
        }

        [HttpPut("modificarSalonero")]
        public string modificarSalonero([FromBody] Salonero salonero)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            SaloneroReglasDeNegocio reglasDeNegocio = new SaloneroReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.modificarSalonero(salonero));
        }

        [HttpPost("crearSalonero")]
        public string crearSalonero([FromBody] Salonero salonero)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            SaloneroReglasDeNegocio reglasDeNegocio = new SaloneroReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.crearSalonero(salonero));
        }
    }
}
