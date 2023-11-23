using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedica
{
    class EmpresaMedica
    {
        private ArrayList listadoEmpleados;
        private ArrayList listadoVehiculos;
        private ArrayList listadoDotaciones;

        public EmpresaMedica()
        {
            this.listadoDotaciones = new ArrayList();
            this.listadoEmpleados = new ArrayList();
            this.listadoVehiculos = new ArrayList();
        }

        public Empleado buscarEmpleado(ulong leg)
        {
            foreach (Empleado aux in this.listadoEmpleados)
            {
                if (aux.getCodigo() == leg)
                {
                    return aux;
                }
            }

            return null;
        }

        public bool agregarEmpleado(Empleado emp)
        {
            if (this.buscarEmpleado(emp.getCodigo()) == null)
            {
                this.listadoEmpleados.Add(emp);
                return true;
            }

            return false;
        }

        public string mostrarEmpleados()
        {
            string datos = "";
            foreach(Empleado aux in this.listadoEmpleados) 
            {
                if (aux is Chofer)
                {
                    datos += "Chofer: \n";
                    datos += "\n";
                }
                else
                {
                    datos += "Profesional: \n";
                    datos += "\n";
                }

                datos += aux.ToString();
                datos += "\n";
            }

            return datos;
        }

        public bool eliminarEmpleado(ulong cod)
        {
            Empleado empEliminar = this.buscarEmpleado(cod);
            if (empEliminar != null)
            {
                if (empEliminar.getIntegraDot())
                {
                    return false;
                }
                else
                {
                    this.listadoEmpleados.Remove(empEliminar);
                    return true;
                }
            }

            return false;
        }

        public Vehiculo buscarVehiculo(string patente)
        {
            foreach (Vehiculo aux in this.listadoVehiculos)
            {
                if (aux.getPatente() == patente)
                {
                    return aux;
                }
            }

            return null;
        }

        public bool agregarVehiculo(Vehiculo veh)
        {
            if(this.buscarVehiculo(veh.getPatente()) == null)
            {
                this.listadoVehiculos.Add(veh);
                return true;
            }

            return false;
        }

        public string mostrarVehiculos()
        {
            string datos = "";

            foreach ( Vehiculo aux in this.listadoVehiculos)
            {
                datos += aux.ToString();
                datos += "\n";
            }

            return datos;
        }

        public void agregarDotacion(Dotacion dot)
        {
            this.listadoDotaciones.Add(dot);
        }

        public string mostrarDotaciones()
        {
            string datos = "";
            foreach(Dotacion aux in this.listadoDotaciones)
            {
                datos += aux.ToString();
                datos += "\n";
            }

            return datos;
        
        }

        public void ordenarVehiculos()
        {
            this.listadoVehiculos.Sort();
        }

        public void ordenarEmpleados()
        {
            this.listadoEmpleados.Sort();
        }

        public string informarDatosEmpleados(ulong leg)
        {
            Empleado emp = this.buscarEmpleado(leg);
            string datos = "";

            if (emp != null)
            {
                if(emp is Chofer)
                {
                    datos += "Chofer: " + emp.getNombre() + "\n";
                    foreach (Dotacion aux in this.listadoDotaciones)
                    {
                        if (emp.getCodigo() == aux.getChofer().getCodigo())
                        {
                            datos += aux.getFecha() + "\n";
                            datos += aux.GetVehiculo().ToString() + "\n"; 
                            return datos;
                        }
                    }
                    return datos;
                }
                else
                {
                    datos += "Profesional: " + emp.getNombre() + "\n";
                    foreach (Dotacion aux in this.listadoDotaciones)
                    {
                        if (emp.getCodigo() == aux.buscarProfesional(leg).getCodigo())
                        {
                            datos += aux.getFecha() + "\n";
                            datos += aux.GetVehiculo().ToString() + "\n";
                            return datos;
                        }
                    }
                    return datos;
                }
            }

            datos += "Empleado inexsistente";
            return datos;

        }


        public string informarDatosDotacion(string pat, string fec)
        {
            string datos = "";
            foreach(Dotacion aux in this.listadoDotaciones)
            {
                if(aux.GetVehiculo().getPatente() == pat && aux.getFecha() == fec)
                {
                    datos += aux.ToString();
                    return datos;
                }
            }
            datos += "No se encontraron dotaciones";
            return datos;
        }






    }
}
