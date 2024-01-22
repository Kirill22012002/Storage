using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class AddBarcodeToParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "barcode",
                table: "Parts",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Part_Barcode",
                table: "Parts",
                column: "barcode",
                unique: true,
                filter: "[barcode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Part_Barcode",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "barcode",
                table: "Parts");
        }
    }
}
