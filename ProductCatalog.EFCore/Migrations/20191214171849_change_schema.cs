using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalog.EFCore.Migrations
{
    public partial class change_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoBinary_Photos_PhotoId",
                table: "PhotoBinary");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhotos_Photos_PhotoId",
                table: "ProductPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhotos_Product_ProductId",
                table: "ProductPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPhotos",
                table: "ProductPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ProductPhotos_PhotoId",
                table: "ProductPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "PhotoBinary",
                newName: "PhotoBinary",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "ProductPhotos",
                newName: "ProductPhoto",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo",
                newSchema: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPhotos_ProductId",
                schema: "Catalog",
                table: "ProductPhoto",
                newName: "IX_ProductPhoto_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPhoto",
                schema: "Catalog",
                table: "ProductPhoto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                schema: "Catalog",
                table: "Photo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhoto_PhotoId_ProductId",
                schema: "Catalog",
                table: "ProductPhoto",
                columns: new[] { "PhotoId", "ProductId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoBinary_Photo_PhotoId",
                schema: "Catalog",
                table: "PhotoBinary",
                column: "PhotoId",
                principalSchema: "Catalog",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhoto_Photo_PhotoId",
                schema: "Catalog",
                table: "ProductPhoto",
                column: "PhotoId",
                principalSchema: "Catalog",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhoto_Product_ProductId",
                schema: "Catalog",
                table: "ProductPhoto",
                column: "ProductId",
                principalSchema: "Catalog",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoBinary_Photo_PhotoId",
                schema: "Catalog",
                table: "PhotoBinary");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhoto_Photo_PhotoId",
                schema: "Catalog",
                table: "ProductPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhoto_Product_ProductId",
                schema: "Catalog",
                table: "ProductPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPhoto",
                schema: "Catalog",
                table: "ProductPhoto");

            migrationBuilder.DropIndex(
                name: "IX_ProductPhoto_PhotoId_ProductId",
                schema: "Catalog",
                table: "ProductPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                schema: "Catalog",
                table: "Photo");

            migrationBuilder.RenameTable(
                name: "PhotoBinary",
                schema: "Catalog",
                newName: "PhotoBinary");

            migrationBuilder.RenameTable(
                name: "ProductPhoto",
                schema: "Catalog",
                newName: "ProductPhotos");

            migrationBuilder.RenameTable(
                name: "Photo",
                schema: "Catalog",
                newName: "Photos");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPhoto_ProductId",
                table: "ProductPhotos",
                newName: "IX_ProductPhotos_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPhotos",
                table: "ProductPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_PhotoId",
                table: "ProductPhotos",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoBinary_Photos_PhotoId",
                table: "PhotoBinary",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhotos_Photos_PhotoId",
                table: "ProductPhotos",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhotos_Product_ProductId",
                table: "ProductPhotos",
                column: "ProductId",
                principalSchema: "Catalog",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
