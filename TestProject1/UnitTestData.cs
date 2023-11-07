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
            Producto producto = new Producto();
            producto.Nombre = "California Chrunchy";
            producto.Precio = 3995.00m;
            producto.Descripcion = "Pepino, aguacate,zanahoria, surime y alga";
            producto.Categoria = 12;
            producto.Habilitado = true;
            producto.Imagen = "california.png";

            ProductoData data = new ProductoData(connectionString);
            data.buscarProducto("ca");
        }
    }
}
