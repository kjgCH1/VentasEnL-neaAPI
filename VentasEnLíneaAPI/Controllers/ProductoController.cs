using Microsoft.AspNetCore.Mvc;
using Entidades;
using ReglasDeNegocio;
using Data;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VentasEnLíneaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//Ensablado de clase
    public class ProductoController : ControllerBase
    {
        public List<Producto> buscarProducto()
        {
        string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
        ProductoData data = new ProductoData(connectionString);
        return data.buscarProducto("");
        }
        [HttpGet("buscarProductoCategoria")]
        public List<Producto> buscarProductoCategoria(int categoria)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            ProductoData data = new ProductoData(connectionString);
            return data.buscarProductoCategoria(categoria);
        }

        [HttpPost("crearProducto")]
        public string crearProducto([FromBody] Producto producto)
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            ProductoReglasDeNegocio reglasDeNegocio = new ProductoReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.crearProducto(producto));
        }
    }
}
