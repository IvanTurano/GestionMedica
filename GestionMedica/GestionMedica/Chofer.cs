namespace GestionMedica
{
    public class Chofer : Empleado
    {
        private uint numRegistro;
        private string distEmision;
        private Vehiculo vehAsignado;

        public Chofer(ulong cod, string nom, string ape, uint num, string dist) : base(cod, nom, ape)
        {
            this.numRegistro = num;
            this.distEmision = dist;
            this.vehAsignado = null;
        }

        public Chofer(ulong cod, string nom, string ape, uint num, string dist, Vehiculo veh) : base(cod, nom, ape)
        {
            this.numRegistro = num;
            this.distEmision = dist;
            this.vehAsignado = veh;
        }

        public void setnumRegistro(uint num) { this.numRegistro = num; }

        public uint getnumRegistro() { return this.numRegistro; }

        public void setdistEmision(string dist) { this.distEmision = dist; }

        public string getdistEmision() { return this.distEmision; }

        public void setVehiculo(Vehiculo veh) { this.vehAsignado = veh; }

        public Vehiculo getVehiculo() { return this.vehAsignado; }

        public override string ToString()
        {
            string datos = base.ToString();
            datos += "Numero de registro de conducir: " + this.numRegistro + "\n";
            datos += "Distrito de emision del registro: " + this.distEmision + "\n";
            return datos;
        }
    }
}
