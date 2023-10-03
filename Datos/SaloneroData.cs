using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using En
namespace VentasEnLíneaData
{
    internal class SaloneroData
    {

        private string connectionString;

        SaloneroData(string connectionString)
        {
            this.connectionString = connectionString;
        }


    }
}
