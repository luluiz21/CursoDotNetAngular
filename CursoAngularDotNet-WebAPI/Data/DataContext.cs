using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CursoAngularDotNet_WebAPI{

    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }
        public DbSet<Departamento> Departamentos {get; set; }
        public DbSet<Funcionario> Funcionarios {get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Departamento>()
            .HasData(new List<Departamento>(){
                new Departamento(1, "Tecnologia", "TI"),
                new Departamento(2, "Recursos Humanos", "RH"),
                new Departamento(3, "Administrativo", "ADM"),
                new Departamento(4, "Financeiro", "FIN"),
                new Departamento(5, "Comercial", "COM")
                
            });

            builder.Entity<Funcionario>()
            .HasData(new List<Funcionario>(){
                new Funcionario(1,"Luiz","foto","54226987-4",3),
                new Funcionario(2,"Frederico","foto","12226987-4",1),
                new Funcionario(3,"Santos","foto","55226955-4",1),
                new Funcionario(4,"Queiroz","foto","55255987-4",2),
                new Funcionario(5,"Junior","foto","51126987-4",4),
                new Funcionario(6,"Luiza","foto","32226987-4",5),
                new Funcionario(7,"Margarida","foto","55224387-4",2),
                new Funcionario(8,"Larissa","foto","30226987-4",1),
                new Funcionario(9,"João","foto","50126987-4",1),
                new Funcionario(10,"Arthur","foto","52269877-4",6),
                new Funcionario(11,"Iago","foto","99226987-4",7)
            });
        }

    }
}