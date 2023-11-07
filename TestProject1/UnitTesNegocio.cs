using Xunit;
using ReglasDeNegocio;

namespace TestProject1
{
    public class UnitTesNegocio
    {
        [Fact]
        public void Test1()
        {
            string connectionString = "workstation id=WokAndRoll.mssql.somee.com;packet size=4096;user id=chesky22_SQLLogin_1;pwd=44a9mwmwsr;data source=WokAndRoll.mssql.somee.com;persist security info=False;initial catalog=WokAndRoll";

            ProductoReglasDeNegocio reglasDeNegocio = new ProductoReglasDeNegocio(connectionString);

            reglasDeNegocio.buscarProducto("ca");
            
        }
    }
}
