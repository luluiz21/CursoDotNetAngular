using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoAngularDotNet_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    foto = table.Column<string>(nullable: true),
                    rg = table.Column<string>(nullable: true),
                    iddepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome", "sigla" },
                values: new object[] { 1, "Tecnologia", "TI" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome", "sigla" },
                values: new object[] { 2, "Recursos Humanos", "RH" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome", "sigla" },
                values: new object[] { 3, "Administrativo", "ADM" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome", "sigla" },
                values: new object[] { 4, "Financeiro", "FIN" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome", "sigla" },
                values: new object[] { 5, "Comercial", "COM" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 1, "foto", 3, "Luiz", "54226987-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 2, "foto", 1, "Frederico", "12226987-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 3, "foto", 1, "Santos", "55226955-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 4, "foto", 2, "Queiroz", "55255987-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 5, "foto", 4, "Junior", "51126987-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 6, "foto", 5, "Luiza", "32226987-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 7, "foto", 2, "Margarida", "55224387-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 8, "foto", 1, "Larissa", "30226987-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 9, "foto", 1, "João", "50126987-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 10, "foto", 6, "Arthur", "52269877-4" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "foto", "iddepartamento", "nome", "rg" },
                values: new object[] { 11, "foto", 7, "Iago", "99226987-4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
