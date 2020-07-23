using Microsoft.EntityFrameworkCore.Migrations;

namespace Lex.Data.Migrations
{
    public partial class discount_rate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NewPrice",
                table: "products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "products");
        }
    }
}
