using Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReglasDeNegocio;

namespace VentasEnLíneaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//Ensablado de clase
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public string BuscarComunidad()
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            CategoriaReglasDeNegocio reglasDeNegocio = new CategoriaReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarCategoria(""));
        }

        [HttpGet("buscarCategoria")]
        public string BuscarCategoria(string parametroBusqueda)
        {
            if (string.IsNullOrEmpty(parametroBusqueda))
            {
                return "El parámetro de búsqueda no puede estar vacío.";
            }

            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            CategoriaReglasDeNegocio reglasDeNegocio = new CategoriaReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarCategoria(parametroBusqueda));
        }

        [HttpGet("buscarCategoriaId")]
        public string BuscarCategoria(int id)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            CategoriaReglasDeNegocio reglasDeNegocio = new CategoriaReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarCategoriaId(id));
        }

        [HttpPut("modificarCategoria")]
        public string modificarCategoria([FromBody] Categoria categoria)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            CategoriaReglasDeNegocio reglasDeNegocio = new CategoriaReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.modificarCategoria(categoria));
        }

        [HttpPost("crearCategoria")]
        public string crearComunidad([FromBody] Categoria categoria)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            CategoriaReglasDeNegocio reglasDeNegocio = new CategoriaReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.crearCategoria(categoria));
        }
    }
}
