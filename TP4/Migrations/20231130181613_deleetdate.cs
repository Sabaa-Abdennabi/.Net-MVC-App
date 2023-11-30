using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP4.Migrations
{
    public partial class deleetdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "movies",
                type: "datetime2",
                nullable: true);
        }
    }
}
