namespace GestionMedica
{
    public class Profesional:Empleado
    {
        private ushort matricula;
        private Categoria categoria;

        public Profesional(ulong cod, string nom, string ape, ushort mat, Categoria cat) : base(cod, nom, ape)
        {
            this.matricula = mat;
            this.categoria = cat;
        }

        public void setMatricula(ushort matricula) { this.matricula = matricula; }

        public ushort getMatricula() {  return this.matricula; }

        public void setCategoria(Categoria cat) { this.categoria = cat; }

        public Categoria getCategoria() {  return this.categoria; }

        public override string ToString()
        {
            string datos = base.ToString();
            datos += "Numero de matricula: " + this.matricula + "\n";
            datos += "Categoria: " + this.categoria + "\n";
            return datos;
        }

    }
}
