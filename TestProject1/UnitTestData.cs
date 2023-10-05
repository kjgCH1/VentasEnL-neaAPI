using System;
using Xunit;
using Data;
using Entidades;

namespace TestProject1
{
    public class UnitTestData
    {
        [Fact]
        public void Test1()
        {
            Comunidad comunidad = new Comunidad();
            comunidad.Nombre = "Coyol";
            comunidad.Precio = 1000.00;
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";

            ComunidadData comunidadData = new ComunidadData(connectionString);
            comunidadData.crearComunidad(comunidad);
            
        }
    }
}
