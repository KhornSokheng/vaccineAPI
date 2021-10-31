using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineAPI.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    ContinentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContinentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.ContinentID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    ContinentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentID",
                        column: x => x.ContinentID,
                        principalTable: "Continents",
                        principalColumn: "ContinentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    VaccineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountryCountryID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.VaccineID);
                    table.ForeignKey(
                        name: "FK_Vaccines_Countries_OriginCountryCountryID",
                        column: x => x.OriginCountryCountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    VaccinationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    VaccineID = table.Column<int>(type: "int", nullable: false),
                    FirstDose = table.Column<int>(type: "int", nullable: false),
                    SecondDose = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.VaccinationID);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Vaccines_VaccineID",
                        column: x => x.VaccineID,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "ContinentID", "ContinentName" },
                values: new object[,]
                {
                    { 1, "Asia" },
                    { 2, "Europe" },
                    { 3, "Africa" },
                    { 4, "North America" },
                    { 5, "South America" },
                    { 6, "Australia" },
                    { 7, "Antarctica" }
                });

            migrationBuilder.InsertData(
                table: "Vaccines",
                columns: new[] { "VaccineID", "Description", "OriginCountryCountryID", "VaccineName" },
                values: new object[,]
                {
                    { 1, "Viral Vector", null, "AstraZeneca" },
                    { 2, "mRNA", null, "Pfizer" },
                    { 3, "Inactivated Virus", null, "Sinovac" },
                    { 4, "Inactivated Virus", null, "Sinopharm" },
                    { 5, "mRNA", null, "Moderna" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "ContinentID", "CountryName", "Population" },
                values: new object[,]
                {
                    { 1, 1, "Brunei", 500000 },
                    { 2, 1, "Cambodia", 15000000 },
                    { 3, 1, "Laos", 7000000 },
                    { 4, 1, "Thailand", 65000000 },
                    { 5, 2, "England", 55000000 },
                    { 6, 4, "United State", 355000000 },
                    { 7, 6, "Australia", 25000000 }
                });

            migrationBuilder.InsertData(
                table: "Vaccinations",
                columns: new[] { "VaccinationID", "CountryID", "FirstDose", "Percentage", "SecondDose", "VaccineID" },
                values: new object[,]
                {
                    { 1, 1, 200000, 0.29999999999999999, 100000, 1 },
                    { 2, 1, 200000, 0.40000000000000002, 200000, 2 },
                    { 3, 1, 50000, 0.10000000000000001, 50000, 3 },
                    { 4, 2, 1000000, 0.059999999999999998, 1000000, 1 },
                    { 5, 2, 9000000, 0.59999999999999998, 9000000, 3 },
                    { 6, 2, 3500000, 0.23000000000000001, 3500000, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentID",
                table: "Countries",
                column: "ContinentID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_CountryID",
                table: "Vaccinations",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccineID",
                table: "Vaccinations",
                column: "VaccineID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_OriginCountryCountryID",
                table: "Vaccines",
                column: "OriginCountryCountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
