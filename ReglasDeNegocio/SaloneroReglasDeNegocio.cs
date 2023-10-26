using Data;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class SaloneroReglasDeNegocio
    {
        private string connectionString;

        public SaloneroReglasDeNegocio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Salonero> buscarSalonero(string nombre)
        {
            SaloneroData data = new SaloneroData(this.connectionString);
            return data.buscarSalonero(nombre);
        }

        public Salonero buscarSaloneroId(int id)
        {
            SaloneroData data = new SaloneroData(this.connectionString);
            return data.buscarSaloneroId(id);
        }

        public bool modificarSalonero(Salonero salonero)
        {
            SaloneroData data = new SaloneroData(this.connectionString);
            return data.modificarSalonero(salonero);
        }

        public bool crearSalonero(Salonero salonero)
        {
            SaloneroData data = new SaloneroData(this.connectionString);
            return data.crearSalonero(salonero);
        }

    }
}
