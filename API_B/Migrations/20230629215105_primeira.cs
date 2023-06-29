using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_B.Migrations
{
    /// <inheritdoc />
    public partial class primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mes = table.Column<int>(type: "INTEGER", nullable: true),
                    ano = table.Column<int>(type: "INTEGER", nullable: true),
                    horas = table.Column<float>(type: "REAL", nullable: true),
                    valor = table.Column<float>(type: "REAL", nullable: true),
                    bruto = table.Column<float>(type: "REAL", nullable: true),
                    irrf = table.Column<float>(type: "REAL", nullable: true),
                    inss = table.Column<float>(type: "REAL", nullable: true),
                    fgts = table.Column<float>(type: "REAL", nullable: true),
                    liquido = table.Column<float>(type: "REAL", nullable: true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");
        }
    }
}
