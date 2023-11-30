using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP4.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "memebrshiptypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignUpFee = table.Column<float>(type: "real", nullable: false),
                    DurationMonth = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memebrshiptypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genresid = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_Genres_Genresid",
                        column: x => x.Genresid,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    memebrshiptypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customers_memebrshiptypes_memebrshiptypesId",
                        column: x => x.memebrshiptypesId,
                        principalTable: "memebrshiptypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersMovies",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersMovies", x => new { x.CustomersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CustomersMovies_customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersMovies_movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "GenreFromJsonFile1" },
                    { 2, "GenreFromJsonFile2" }
                });

            migrationBuilder.InsertData(
                table: "memebrshiptypes",
                columns: new[] { "id", "DiscountRate", "DurationMonth", "SignUpFee" },
                values: new object[,]
                {
                    { 1, 0f, 1, 50f },
                    { 2, 5f, 3, 100f },
                    { 3, 10f, 6, 150f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_memebrshiptypesId",
                table: "customers",
                column: "memebrshiptypesId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersMovies_MoviesId",
                table: "CustomersMovies",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_Genresid",
                table: "movies",
                column: "Genresid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersMovies");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "memebrshiptypes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
