namespace CursoAngularDotNet_WebAPI{
    
    public class Funcionario{

        public Funcionario(){

        }
        public Funcionario(int id, string nome,string foto, string rg,int iddepartamento){
            this.Id= id;
            this.Nome = nome;
            this.Foto = foto;
            this.Rg = rg;
            this.IdDepartamento = iddepartamento;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Rg {get; set; }
        public int IdDepartamento {get; set; }
    }
    
}