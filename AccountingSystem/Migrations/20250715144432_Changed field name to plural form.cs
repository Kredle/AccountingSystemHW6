using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Changedfieldnametopluralform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchasesCategory_CategoryId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasesCategory",
                table: "PurchasesCategory");

            migrationBuilder.RenameTable(
                name: "PurchasesCategory",
                newName: "PurchasesCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasesCategories",
                table: "PurchasesCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchasesCategories_CategoryId",
                table: "Purchases",
                column: "CategoryId",
                principalTable: "PurchasesCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchasesCategories_CategoryId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasesCategories",
                table: "PurchasesCategories");

            migrationBuilder.RenameTable(
                name: "PurchasesCategories",
                newName: "PurchasesCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasesCategory",
                table: "PurchasesCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchasesCategory_CategoryId",
                table: "Purchases",
                column: "CategoryId",
                principalTable: "PurchasesCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
