using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Reporte
    {
        public int id;
        public string detalle;
        public int administrador;
        public string fecha;

        public Reporte() { }

        public Reporte(int id, string detalle, int administrador, string fecha)
        {
            this.id = id;
            this.detalle = detalle;
            this.administrador = administrador;
            this.fecha = fecha;
        }

        public int Id { get =>  id; set => id = value; }
        public string Detalle { get => detalle; set => detalle = value; }

        public int Administrador { get => administrador; set => administrador = value; }

        public string Fecha { get => fecha; set => fecha = value; }
    }
}
