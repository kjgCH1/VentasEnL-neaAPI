using System;
using Data;
using Entidades;

namespace ReglasDeNegocio
{
    public class ComunidadReglasDeNegocio
    {
        private string connectionString;

        public ComunidadReglasDeNegocio(string connectionString) { 
            this.connectionString = connectionString;
        }
        public bool crearComunidad(Comunidad comunidad) {
            ComunidadData data= new ComunidadData(this.connectionString);
            return data.crearComunidad(comunidad);
        }
    }
}
