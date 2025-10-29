using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedPasswordsToPlainText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Admin123!");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "Usuario123!");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEHZ3mXKqHwJ9vN7yQcF4R1tP8aL5sB6xD2kE9fM3nG7hI0jC1uO4pW8zV5qY6rT3A==");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEKL9wX3tN5mP2zR8sV4cU6hJ1bY7eO9qT4rI0pA5sF8dG3kM6nC1xW2vZ7yH8jB0E==");
        }
    }
}
