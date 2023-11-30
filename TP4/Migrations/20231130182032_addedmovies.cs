using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP4.Migrations
{
    public partial class addedmovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "Id", "Genresid", "Name" },
                values: new object[] { 1, 1, "No time to die" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "Id", "Genresid", "Name" },
                values: new object[] { 2, 2, "No time to die2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
