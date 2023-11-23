using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedica
{
    class Ambulancia:Vehiculo
    {
        private Tipos tipoDeAmbu;

        public Ambulancia(string pat, string mar, string mod, string tipo, Tipos tipoDeAmbu):base(pat,mar,mod,tipo)
        {
            this.tipoDeAmbu = tipoDeAmbu;
        }

        public override string ToString()
        {
            string datos = "";
            datos += "Patente: " + getPatente() + "\n";
            datos += "Marca: " + getMarca() + "\n";
            datos += "Modelo: " + getModelo() + "\n";
            datos += "Tipo de vehiculo: " + getTipo() + "\n";
            datos += "Tipo de Ambulancia: " + this.tipoDeAmbu.ToString() + "\n";
            return datos;
        }


    }
}
