using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyHelmet.Migrations
{
    public partial class AddRefnumberToHelmetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Refnumber",
                table: "Helmet",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Refnumber",
                table: "Helmet");
        }
    }
}
