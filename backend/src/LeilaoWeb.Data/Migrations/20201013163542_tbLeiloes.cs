using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeilaoWeb.Data.Migrations
{
    public partial class tbLeiloes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leiloes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    ValorInicial = table.Column<decimal>(nullable: false),
                    Condicao = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DataAbetura = table.Column<DateTime>(type: "date", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(type: "date", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leiloes");
        }
    }
}
