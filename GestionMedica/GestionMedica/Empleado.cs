namespace GestionMedica
{
    public class Empleado:IComparable
    {
        private ulong codigo;
        private string nombre;
        private string apellido;
        private bool integraDot;

        public Empleado(ulong codigo, string nombre, string apellido)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.integraDot = false;
        }

        public void setCodigo(ulong cod) { this.codigo = cod; }
   
        public ulong getCodigo() { return this.codigo; }

        public void setNombre(string nom) { this.nombre = nom; }

        public string getNombre() {  return this.nombre; }

        public void setApellido(string ape) { this.apellido = ape; }

        public string getApellido() {  return this.apellido; }

        public void setIntegraDot(bool integra)
        {
            this.integraDot = integra;
        }

        public bool getIntegraDot() { return this.integraDot; }

        public override string ToString()
        {
            string datos = "";
            datos += "Codigo de identificación personal: " + this.codigo + "\n";
            datos += "Nombre: " + this.nombre + "\n";
            datos += "Apellido: " + this.apellido + "\n";
            return datos;
        }

        public int CompareTo(object empleado)
        {
            return this.apellido.CompareTo(((Empleado)empleado).getApellido());
        }
    }
}
