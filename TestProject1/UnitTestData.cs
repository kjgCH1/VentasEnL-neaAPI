using System;
using Xunit;
using Data;
using Entidades;
using System.Collections.Generic;

namespace TestProject1
{
    public class UnitTestData
    {
        [Fact]
        public void Test1()
        {
           
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";

            ComunidadData comunidadData = new ComunidadData(connectionString);
            Comunidad comunidad = new Comunidad();
            comunidad.Nombre = "Don Tomas";
            comunidad.Precio = 1000.0m;
            comunidad.Id = 42;
            comunidadData.modificarComunidad(comunidad);



        }
    }
}
