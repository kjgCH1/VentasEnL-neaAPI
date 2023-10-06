using System;
using System.Collections.Generic;
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

        public List<Comunidad> buscarComunidad(string nombre) { 
            ComunidadData data = new ComunidadData(this.connectionString);
            return data.buscarComunidad(nombre);
        }
    }
}
