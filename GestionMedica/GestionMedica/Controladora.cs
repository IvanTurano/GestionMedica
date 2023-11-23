
using System.ComponentModel;

namespace GestionMedica
{
    internal class Controladora
    {
        public static void Main()
        {
            char opcion;
            EmpresaMedica empresaMedica = new EmpresaMedica();
            do
            {
                char.TryParse(Interfaz.DarOpcion().ToUpper(), out opcion);
                //.ToUpper() Convierte la cadena a MAYÚSCULAS.
                switch (opcion)
                {
                    case 'A':
                        string op = Interfaz.PedirDato("[C] = Registrar un Chofer, [P] = Registrar un profesional de la salud").ToUpper();
                        if (op == "C")
                        {
                            ulong co = ulong.Parse(Interfaz.PedirDato("Codigo de empleado"));
                            string nom = Interfaz.PedirDato("Nombre del empleado");
                            string ape = Interfaz.PedirDato("Apellido del empleado");
                            uint nRegistro = uint.Parse(Interfaz.PedirDato("Numero de registro"));
                            string distri = Interfaz.PedirDato("Distrito de emision de registro");
                            empresaMedica.agregarEmpleado(new Chofer(co, nom, ape, nRegistro, distri));
                        }
                        else if (op == "P")
                        {
                            ulong codi = ulong.Parse(Interfaz.PedirDato("Codigo de empleado"));
                            string nom = Interfaz.PedirDato("Nombre del empleado");
                            string ape = Interfaz.PedirDato("Apellido del empleado");
                            ushort mat = ushort.Parse(Interfaz.PedirDato("Matricula del profesional"));
                            string cat = Interfaz.PedirDato("[A] = Medico, [B] = Enfermero, [C] = Paramedico").ToUpper();
                            if(cat == "A")
                            {
                                Categoria cate = Categoria.Medico;
                                empresaMedica.agregarEmpleado(new Profesional(codi,nom,ape,mat,cate));
                            }
                            else if (cat == "B")
                            {
                                Categoria cate = Categoria.Enfermero;
                                empresaMedica.agregarEmpleado(new Profesional(codi, nom, ape, mat, cate));
                            }
                            else if (cat == "C")
                            {
                                Categoria cate = Categoria.Paramedico;
                                empresaMedica.agregarEmpleado(new Profesional(codi, nom, ape, mat, cate));
                            }
                            else
                            {
                                Interfaz.MostrarInfo("Opcion invalida");
                            }

                        }
                        break;

                    case 'B':
                        op = Interfaz.PedirDato("[A] = Registrar un Auto, [B] = Registrar una Ambulancia").ToUpper();
                        if (op == "A")
                        {
                            string pate = Interfaz.PedirDato("Patente");
                            string mar = Interfaz.PedirDato("Marca");
                            string model = Interfaz.PedirDato("Modelo");
                            empresaMedica.agregarVehiculo(new Vehiculo(pate, mar, model,"Auto"));

                        }
                        else if (op == "B")
                        {
                            string paten = Interfaz.PedirDato("Patente");
                            string mar = Interfaz.PedirDato("Marca");
                            string model = Interfaz.PedirDato("Modelo");
                            string tip = Interfaz.PedirDato("Tipo de ambulancia : [A] = EMG, [B] = UTIM, [C] = UCM").ToUpper();
                            if (tip == "A")
                            {
                                Tipos tipo = Tipos.EMG;
                                empresaMedica.agregarVehiculo(new Ambulancia(paten, mar, model, "Ambulancia", tipo));
                            }
                            else if (tip == "B")
                            {
                                Tipos tipo = Tipos.UTIM;
                                empresaMedica.agregarVehiculo(new Ambulancia(paten, mar, model, "Ambulancia", tipo));
                            }
                            else if (tip == "C")
                            {
                                Tipos tipo = Tipos.UCM;
                                empresaMedica.agregarVehiculo(new Ambulancia(paten, mar, model, "Ambulancia", tipo));
                            }
                        }
                        break;

                    case 'C':
                        ulong cod = ulong.Parse(Interfaz.PedirDato("Codigo de chofer"));
                        Empleado chof = empresaMedica.buscarEmpleado(cod);
                        if ( chof != null)
                        {
                            empresaMedica.buscarEmpleado(cod).setIntegraDot(true);
                            chof.setIntegraDot(true);
                            Dotacion dot = new Dotacion();
                            dot.setChofer((Chofer)chof);

                            string fec = Interfaz.PedirDato("Ingrese la fecha");
                            dot.setFecha(fec);

                            int cant = int.Parse(Interfaz.PedirDato("Cuanto profesionales va a derivar al vehiculo?"));
                            for(int i = 0; i < cant; i++)
                            {
                                ulong co = ulong.Parse(Interfaz.PedirDato("Codigo de empleado"));
                                Empleado pro = empresaMedica.buscarEmpleado(co);
                                if ( pro != null)
                                {
                                    empresaMedica.buscarEmpleado(co).setIntegraDot(true);
                                    pro.setIntegraDot(true);
                                    dot.agregarProfesional((Profesional)pro);
                                }
                            }
                            string pate = Interfaz.PedirDato("Patente del vehiculo");
                            Vehiculo veh = empresaMedica.buscarVehiculo(pate);
                            if (cant > 2)
                            {
                                if (veh is Ambulancia)
                                {
                                    dot.setVehiculo(veh);
                                    empresaMedica.agregarDotacion(dot);

                                }
                                else
                                {
                                    Interfaz.MostrarInfo("Debe asignar una ambulancia para la cantidad de 3 personas o más");
                                }
                            }
                            else
                            {
                                dot.setVehiculo(veh);
                                empresaMedica.agregarDotacion(dot);
                            }
                        }
                        else
                        {
                            Interfaz.MostrarInfo("No hay choferes con ese codigo");
                        }
                        break;

                    case 'D':
                        empresaMedica.ordenarEmpleados();
                        Interfaz.MostrarInfo(empresaMedica.mostrarEmpleados());
                        break;

                    case 'E':
                        empresaMedica.ordenarVehiculos();
                        Interfaz.MostrarInfo(empresaMedica.mostrarVehiculos());
                        break;

                    case 'F':
                        Interfaz.MostrarInfo(empresaMedica.mostrarDotaciones());
                        break;

                    case 'G':
                        cod = ulong.Parse(Interfaz.PedirDato("Codigo de empleado a eliminar"));
                        if (empresaMedica.eliminarEmpleado(cod))
                        {
                            Interfaz.MostrarInfo("Empleado eliminado");
                        }
                        else
                        {
                            Interfaz.MostrarInfo("Empleado inexsistente o integra una dotación");
                        }
                        break;

                    case 'H':
                        ulong leg = ulong.Parse(Interfaz.PedirDato("Legajo del empleado"));
                        Interfaz.MostrarInfo(empresaMedica.informarDatosEmpleados(leg));
                        break;

                    case 'I':
                        string pat = Interfaz.PedirDato("Patente del vehiculo asignado a la dotación");
                        string fecha = Interfaz.PedirDato("Fecha de la dotación");
                        Interfaz.MostrarInfo(empresaMedica.informarDatosDotacion(pat, fecha));
                        break;


                }



            } while (opcion != 'S');


        }


    }
}
