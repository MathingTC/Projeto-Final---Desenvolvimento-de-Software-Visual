using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSeedEtapas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "Id", "Descricao", "Ordem", "ReceitaId" },
                values: new object[,]
                {
                    { new Guid("125f8380-478c-4c4e-bde6-e0b0f4c6790f"), "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela", 2, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("3dad37a1-36c5-401d-9e83-7a2038844f31"), "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda", 1, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("75b168ed-76a2-441f-b576-5d5cd9b1f1e2"), "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado", 3, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("125f8380-478c-4c4e-bde6-e0b0f4c6790f"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("3dad37a1-36c5-401d-9e83-7a2038844f31"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("75b168ed-76a2-441f-b576-5d5cd9b1f1e2"));
        }
    }
}
