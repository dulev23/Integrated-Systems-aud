using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Onion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_Products_AddedProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_AddedShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductInShoppingCarts_AddedProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductInShoppingCarts_AddedShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropColumn(
                name: "AddedProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropColumn(
                name: "AddedShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Products",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Products",
                newName: "Description");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShoppingCartId",
                table: "ProductInShoppingCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "ProductInShoppingCarts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShoppingCarts_ProductId",
                table: "ProductInShoppingCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShoppingCarts_ShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ProductId",
                table: "ProductInShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductInShoppingCarts_ProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductInShoppingCarts_ShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Products",
                newName: "ProductImage");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "ProductDescription");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ProductInShoppingCarts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "ProductInShoppingCarts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AddedProductId",
                table: "ProductInShoppingCarts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddedShoppingCartId",
                table: "ProductInShoppingCarts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShoppingCarts_AddedProductId",
                table: "ProductInShoppingCarts",
                column: "AddedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShoppingCarts_AddedShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "AddedShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_Products_AddedProductId",
                table: "ProductInShoppingCarts",
                column: "AddedProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_AddedShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "AddedShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
