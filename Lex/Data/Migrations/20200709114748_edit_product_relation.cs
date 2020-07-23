using Microsoft.EntityFrameworkCore.Migrations;

namespace Lex.Data.Migrations
{
    public partial class edit_product_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_AspNetUsers_ShopId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "products",
                newName: "ShopID");

            migrationBuilder.RenameIndex(
                name: "IX_products_ShopId",
                table: "products",
                newName: "IX_products_ShopID");

            migrationBuilder.AddForeignKey(
                name: "FK_products_AspNetUsers_ShopID",
                table: "products",
                column: "ShopID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_AspNetUsers_ShopID",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ShopID",
                table: "products",
                newName: "ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ShopID",
                table: "products",
                newName: "IX_products_ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_AspNetUsers_ShopId",
                table: "products",
                column: "ShopId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
