using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedica
{
    public class Vehiculo:IComparable
    {
        private string patente;
        private string marca;
        private string modelo;
        private string tipo;

        public Vehiculo(string patente, string marca, string modelo, string tipo)
        {
            this.patente = patente;
            this.marca = marca;
            this.modelo = modelo;
            this.tipo = tipo;
        }


        public void setPatente (string patente) { this.patente= patente; }

        public string getPatente() { return this.patente; }

        public void setMarca(string marca) { this.marca = marca; }

        public string getMarca() { return this.marca; }

        public void setModelo(string modelo) { this.modelo= modelo; }

        public string getModelo() { return this.modelo; }

        public void setTipo(string tipo) { this.tipo = tipo; }

        public string getTipo() { return this.tipo; }

        public override string ToString()
        {
            string datos = "";
            datos += "Patente: " + this.patente + "\n";
            datos += "Marca: " + this.marca + "\n";
            datos += "Modelo: " + this.modelo + "\n";
            datos += "Tipo de vehiculo: " + this.tipo + "\n";
            return datos;
        }

        public int CompareTo(object veh)
        {
            return this.patente.CompareTo(((Vehiculo)veh).getPatente());
        }
    }
}
