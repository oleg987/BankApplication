using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApplication.Migrations.DataDb
{
    public partial class AddIsDeletedColumnToPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Persons",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Persons");
        }
    }
}
