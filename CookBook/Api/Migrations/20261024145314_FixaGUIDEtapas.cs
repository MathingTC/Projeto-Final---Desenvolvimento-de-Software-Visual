using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FixaGUIDEtapas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("24ac928d-ce6a-49c0-8dcb-6d7898c28d40"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("ce907050-8cf5-404c-ad12-2be6cba2ea3c"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("fd55d3a0-c298-435c-afd3-b268a912deb3"));

            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "Id", "Descricao", "Ordem", "ReceitaId" },
                values: new object[,]
                {
                    { new Guid("3b6d1e94-a7c2-4f05-b18d-e5c90a47d263"), "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado", 3, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("7e3f9a1c-5b24-4d68-9c07-a2f1d84b6e35"), "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda", 1, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("c8a05d72-1f9e-4b3a-8e46-0d7b93f2a1c8"), "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela", 2, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") }
                });

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: new Guid("cf96e0a2-c665-4202-b0b8-200dbfd89d40"),
                column: "Nome",
                value: "Leite Condensado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("3b6d1e94-a7c2-4f05-b18d-e5c90a47d263"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("7e3f9a1c-5b24-4d68-9c07-a2f1d84b6e35"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("c8a05d72-1f9e-4b3a-8e46-0d7b93f2a1c8"));

            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "Id", "Descricao", "Ordem", "ReceitaId" },
                values: new object[,]
                {
                    { new Guid("24ac928d-ce6a-49c0-8dcb-6d7898c28d40"), "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela", 2, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("ce907050-8cf5-404c-ad12-2be6cba2ea3c"), "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado", 3, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("fd55d3a0-c298-435c-afd3-b268a912deb3"), "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda", 1, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") }
                });

            migrationBuilder.UpdateData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: new Guid("cf96e0a2-c665-4202-b0b8-200dbfd89d40"),
                column: "Nome",
                value: "Leite Consendado");
        }
    }
}
