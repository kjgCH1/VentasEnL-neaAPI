using System;
using System.Collections.Generic;
using System.Text;

namespace VentasEnLíneaEntidades
{
    public class Pedido
    {
        private int id;
        private string fecha;
        private int cliente;
        private int salonero;
        private int direccion;
        private List<int> productos;
        private List<int> ofertas;

        public Pedido() { 
            this.productos = new List<int>();
            this.ofertas = new List<int>();
        }

        public Pedido(int id, string fecha, int cliente, int salonero, int direccion, List<int> productos, List<int> ofertas)
        {
            this.id = id;
            this.fecha = fecha;
            this.cliente = cliente;
            this.salonero = salonero;
            this.direccion = direccion;
            this.productos = productos;
            this.ofertas = ofertas;
        }

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Cliente { get => cliente; set => cliente = value; }
        public int Salonero { get => salonero; set => salonero = value; }
        public int Direccion { get => direccion; set => direccion = value; }
        public List<int> Productos { get => productos; set => productos = value; }
        public List<int> Ofertas { get => ofertas; set => ofertas = value; }
    }
}
