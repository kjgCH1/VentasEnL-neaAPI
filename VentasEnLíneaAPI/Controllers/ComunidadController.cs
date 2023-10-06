﻿using Microsoft.AspNetCore.Mvc;
using ReglasDeNegocio;
using System.Collections.Generic;
using Entidades;
using Newtonsoft.Json;

namespace VentasEnLíneaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//Ensablado de clase
    public class ComunidadController : ControllerBase
    {
        
        [HttpGet]
        public string holamundo() {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";
            ComunidadReglasDeNegocio reglasDeNegocio = new ComunidadReglasDeNegocio(connectionString);
            return JsonConvert.SerializeObject(reglasDeNegocio.buscarComunidad("co"));
        }
    }
}
