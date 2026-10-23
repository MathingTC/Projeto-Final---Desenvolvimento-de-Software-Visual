using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSeedIngredienteReceitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("28677932-c7ab-4368-8ccb-55c8a6ab9e82"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("74f9de47-df6c-4865-aebb-0b25cda68fe8"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("7ab18b03-1e2f-4e37-bdab-0cc46121d17e"));

            migrationBuilder.InsertData(
                table: "Etapas",
                columns: new[] { "Id", "Descricao", "Ordem", "ReceitaId" },
                values: new object[,]
                {
                    { new Guid("1f5527ef-d317-4a95-be75-dbcb35be730b"), "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela", 2, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("5ddc224d-1ffe-4b7b-b831-597934d0ff70"), "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado", 3, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("73dabe6e-dedb-4152-88e7-ebde1e3fcb1d"), "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda", 1, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") }
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
                keyValue: new Guid("1f5527ef-d317-4a95-be75-dbcb35be730b"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("5ddc224d-1ffe-4b7b-b831-597934d0ff70"));

            migrationBuilder.DeleteData(
                table: "Etapas",
                keyColumn: "Id",
                keyValue: new Guid("73dabe6e-dedb-4152-88e7-ebde1e3fcb1d"));

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
                    { new Guid("28677932-c7ab-4368-8ccb-55c8a6ab9e82"), "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda", 1, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("74f9de47-df6c-4865-aebb-0b25cda68fe8"), "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado", 3, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") },
                    { new Guid("7ab18b03-1e2f-4e37-bdab-0cc46121d17e"), "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela", 2, new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe") }
                });
        }
    }
}
