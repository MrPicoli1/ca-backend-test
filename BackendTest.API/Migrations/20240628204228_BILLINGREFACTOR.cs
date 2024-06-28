using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTest.API.Migrations
{
    /// <inheritdoc />
    public partial class BILLINGREFACTOR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billing_Users_CustomerId",
                table: "Billing");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Billing_BillingId",
                table: "BillingLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Products_ProductId",
                table: "BillingLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Billing_BillingId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BillingId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_BillingLines_BillingId",
                table: "BillingLines");

            migrationBuilder.DropIndex(
                name: "IX_BillingLines_ProductId",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Billing");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BillingLines",
                newName: "InvoiceNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Billing",
                newName: "DetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Billing_CustomerId",
                table: "Billing",
                newName: "IX_Billing_DetailsId");

            migrationBuilder.AddColumn<Guid>(
                name: "BillingLinesId",
                table: "Products",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "BillingLines",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "BillingLines",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BillingLines",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "BillingLines",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "BillingLines",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BillingLinesId",
                table: "Products",
                column: "BillingLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_CustomerId",
                table: "BillingLines",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billing_BillingLines_DetailsId",
                table: "Billing",
                column: "DetailsId",
                principalTable: "BillingLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Users_CustomerId",
                table: "BillingLines",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BillingLines_BillingLinesId",
                table: "Products",
                column: "BillingLinesId",
                principalTable: "BillingLines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billing_BillingLines_DetailsId",
                table: "Billing");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Users_CustomerId",
                table: "BillingLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_BillingLines_BillingLinesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BillingLinesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_BillingLines_CustomerId",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "BillingLinesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "BillingLines");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                table: "BillingLines",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DetailsId",
                table: "Billing",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Billing_DetailsId",
                table: "Billing",
                newName: "IX_Billing_CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "BillingId",
                table: "Products",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BillingId",
                table: "BillingLines",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "BillingLines",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BillingLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subtotal",
                table: "BillingLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitPrice",
                table: "BillingLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Billing",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Billing",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "Billing",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Billing",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Billing",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BillingId",
                table: "Products",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_BillingId",
                table: "BillingLines",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_ProductId",
                table: "BillingLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billing_Users_CustomerId",
                table: "Billing",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Billing_BillingId",
                table: "BillingLines",
                column: "BillingId",
                principalTable: "Billing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Products_ProductId",
                table: "BillingLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Billing_BillingId",
                table: "Products",
                column: "BillingId",
                principalTable: "Billing",
                principalColumn: "Id");
        }
    }
}
