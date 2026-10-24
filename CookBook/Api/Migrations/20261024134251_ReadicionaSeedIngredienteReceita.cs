using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ReadicionaSeedIngredienteReceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("0968b1f3-28db-4c68-9f60-36a8cf233fd2"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("85585ffd-fe3b-4821-895c-cccbb3409b25"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("aa49841e-c5d7-43ab-838c-9410eab7f689"));

            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "Id", "Descricao", "Ordem", "ReceitaId" },
                values: new object[,]
                {
                    { new Guid("24ac928d-ce6a-49c0-8dcb-6d7898c28d40"), "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela", 2, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("ce907050-8cf5-404c-ad12-2be6cba2ea3c"), "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado", 3, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("fd55d3a0-c298-435c-afd3-b268a912deb3"), "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda", 1, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") }
                });

            migrationBuilder.InsertData(
                table: "IngredienteReceitas",
                columns: new[] { "IngredienteId", "ReceitaId", "Quantidade", "UnidadeMedida" },
                values: new object[,]
                {
                    { new Guid("59f0d6fc-6fd6-44ad-8333-4890587b07c8"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"), null, "" },
                    { new Guid("5ddff53a-e787-4ad9-9883-39b6cb185aff"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"), 4f, "colheres de sopa" },
                    { new Guid("84582dba-47a5-4463-9047-999374b05ef9"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"), 1f, "colher de sopa" },
                    { new Guid("cf96e0a2-c665-4202-b0b8-200dbfd89d40"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"), 1f, "lata" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "IngredienteReceitas",
                keyColumns: new[] { "IngredienteId", "ReceitaId" },
                keyValues: new object[] { new Guid("59f0d6fc-6fd6-44ad-8333-4890587b07c8"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") });

            migrationBuilder.DeleteData(
                table: "IngredienteReceitas",
                keyColumns: new[] { "IngredienteId", "ReceitaId" },
                keyValues: new object[] { new Guid("5ddff53a-e787-4ad9-9883-39b6cb185aff"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") });

            migrationBuilder.DeleteData(
                table: "IngredienteReceitas",
                keyColumns: new[] { "IngredienteId", "ReceitaId" },
                keyValues: new object[] { new Guid("84582dba-47a5-4463-9047-999374b05ef9"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") });

            migrationBuilder.DeleteData(
                table: "IngredienteReceitas",
                keyColumns: new[] { "IngredienteId", "ReceitaId" },
                keyValues: new object[] { new Guid("cf96e0a2-c665-4202-b0b8-200dbfd89d40"), new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") });

            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "Id", "Descricao", "Ordem", "ReceitaId" },
                values: new object[,]
                {
                    { new Guid("0968b1f3-28db-4c68-9f60-36a8cf233fd2"), "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela", 2, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("85585ffd-fe3b-4821-895c-cccbb3409b25"), "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado", 3, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("aa49841e-c5d7-43ab-838c-9410eab7f689"), "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda", 1, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") }
                });
        }
    }
}
