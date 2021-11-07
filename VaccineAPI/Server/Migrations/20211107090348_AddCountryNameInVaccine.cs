using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineAPI.Server.Migrations
{
    public partial class AddCountryNameInVaccine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Countries_OriginCountryCountryID",
                table: "Vaccines");

            migrationBuilder.RenameColumn(
                name: "OriginCountryCountryID",
                table: "Vaccines",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccines_OriginCountryCountryID",
                table: "Vaccines",
                newName: "IX_Vaccines_CountryID");

            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "Vaccines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Countries_CountryID",
                table: "Vaccines",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Countries_CountryID",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "Vaccines");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Vaccines",
                newName: "OriginCountryCountryID");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccines_CountryID",
                table: "Vaccines",
                newName: "IX_Vaccines_OriginCountryCountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Countries_OriginCountryCountryID",
                table: "Vaccines",
                column: "OriginCountryCountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
