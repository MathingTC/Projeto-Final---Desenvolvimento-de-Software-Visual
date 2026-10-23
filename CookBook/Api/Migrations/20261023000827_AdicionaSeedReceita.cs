using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSeedReceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"), "Doce comum brasileiro", "Brigadeiro" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receitas",
                keyColumn: "Id",
                keyValue: new Guid("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"));
        }
    }
}
