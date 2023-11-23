using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedica
{
    public class Dotacion
    {
        private Chofer chofer;
        private ArrayList profesionales = new ArrayList();
        private Vehiculo vehiculo;
        private string fecha;

        public Dotacion()
        {
            this.chofer = null;
            this.vehiculo = null;
            this.fecha = "no asiganada";
        }

        public Dotacion(Chofer chofer, Vehiculo vehiculo, string fecha)
        {
            this.chofer = chofer;
            this.vehiculo = vehiculo;
            this.fecha = fecha;
        }

        public void setChofer(Chofer chof) { this.chofer = chof; }

        public Chofer getChofer() {  return this.chofer; }

        public void setVehiculo(Vehiculo vehiculo) { this.vehiculo = vehiculo; }

        public Vehiculo GetVehiculo() { return this.vehiculo; }

        public void setFecha(string fec) { this.fecha = fec; }

        public string getFecha() { return fecha;}


        public Profesional buscarProfesional(ulong leg)
        {
            foreach (Profesional aux in this.profesionales)
            {
                if (aux.getCodigo() == leg)
                {
                    return aux;
                }
            }

            return null;
        }

        public bool agregarProfesional(Profesional profe)
        {
            if (this.buscarProfesional(profe.getMatricula()) == null)
            {
                this.profesionales.Add(profe);
                return true;
            }

            return false;
            
        }

        public bool sacarProfesional(ushort matri)
        {
            Profesional prof = buscarProfesional(matri);

            foreach (Profesional aux in this.profesionales)
            {
                if (aux.getMatricula() == prof.getMatricula())
                {
                    this.profesionales.Remove(aux);
                    return true;
                }
            }

            return false;
        }



        public override string ToString()
        {   
            string datos = "Fecha : " + this.fecha + "\n";
            datos += "Chofer : " + this.chofer + "\n";
            datos += "Profesionales : ";
            foreach (Profesional aux in this.profesionales )
            {
                datos += aux.ToString() + "\n"; ;
            }

            datos += "Vehiculo : " + this.vehiculo.ToString() + "\n"; 

            return datos;

        }

    }
}
