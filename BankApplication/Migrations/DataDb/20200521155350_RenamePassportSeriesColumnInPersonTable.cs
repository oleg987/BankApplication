using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApplication.Migrations.DataDb
{
    public partial class RenamePassportSeriesColumnInPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassoprtSeries",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "PassportSeries",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportSeries",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "PassoprtSeries",
                table: "Persons",
                type: "text",
                nullable: true);
        }
    }
}
