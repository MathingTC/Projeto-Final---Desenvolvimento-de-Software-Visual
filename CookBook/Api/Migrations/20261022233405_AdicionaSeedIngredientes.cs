using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSeedIngredientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("59f0d6fc-6fd6-44ad-8333-4890587b07c8"), "Chocolate Granulado" },
                    { new Guid("5ddff53a-e787-4ad9-9883-39b6cb185aff"), "Chocolate em Pó" },
                    { new Guid("84582dba-47a5-4463-9047-999374b05ef9"), "Margarina sem Sal" },
                    { new Guid("cf96e0a2-c665-4202-b0b8-200dbfd89d40"), "Leite Consendado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: new Guid("59f0d6fc-6fd6-44ad-8333-4890587b07c8"));

            migrationBuilder.DeleteData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: new Guid("5ddff53a-e787-4ad9-9883-39b6cb185aff"));

            migrationBuilder.DeleteData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: new Guid("84582dba-47a5-4463-9047-999374b05ef9"));

            migrationBuilder.DeleteData(
                table: "Ingredientes",
                keyColumn: "Id",
                keyValue: new Guid("cf96e0a2-c665-4202-b0b8-200dbfd89d40"));
        }
    }
}
