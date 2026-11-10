using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamGarage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    IsHybrid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Horsepower", "IsElectric", "IsHybrid", "Make", "Model", "Price", "Trim", "Year" },
                values: new object[,]
                {
                    { 1, "Orange", 710, false, false, "McLaren", "720S", 275000, "Performance", 2020 },
                    { 2, "Black", 580, false, false, "Porsche", "911", 200000, "Turbo S", 2018 },
                    { 3, "Lime", 759, false, false, "Lamborghini", "Aventador", 550000, "SVJ", 2022 },
                    { 4, "Blue", 627, false, false, "BMW", "M5", 145000, "CS", 2021 },
                    { 5, "Red", 631, false, true, "Audi", "RS Q8", 135000, "Performance", 2025 },
                    { 6, "Silver", 2107, true, false, "Rimac", "Nevera", 2500000, "R", 2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
