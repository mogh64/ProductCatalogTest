using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.EFCore.Migrations
{
    public partial class add_uniqe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Code",
                schema: "Catalog",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code",
                schema: "Catalog",
                table: "Product",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Code",
                schema: "Catalog",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code",
                schema: "Catalog",
                table: "Product",
                column: "Code");
        }
    }
}
