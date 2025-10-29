using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WAMVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuariosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Email", "NombreCompleto", "Password", "Rol" },
                values: new object[,]
                {
                    { 1, true, "admin@artesanias.com", "Administrador del Sistema", "AQAAAAIAAYagAAAAEHZ3mXKqHwJ9vN7yQcF4R1tP8aL5sB6xD2kE9fM3nG7hI0jC1uO4pW8zV5qY6rT3A==", "Administrador" },
                    { 2, true, "usuario@artesanias.com", "Usuario de Prueba", "AQAAAAIAAYagAAAAEKL9wX3tN5mP2zR8sV4cU6hJ1bY7eO9qT4rI0pA5sF8dG3kM6nC1xW2vZ7yH8jB0E==", "Usuario" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
