using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendTest.API.Migrations
{
    /// <inheritdoc />
    public partial class Billing3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Billing_BillingId1",
                table: "BillingLines");

            migrationBuilder.DropIndex(
                name: "IX_BillingLines_BillingId1",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "BillingId1",
                table: "BillingLines");

            migrationBuilder.AlterColumn<int>(
                name: "BillingId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Billing",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_BillingId",
                table: "BillingLines",
                column: "BillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Billing_BillingId",
                table: "BillingLines",
                column: "BillingId",
                principalTable: "Billing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Billing_BillingId",
                table: "BillingLines");

            migrationBuilder.DropIndex(
                name: "IX_BillingLines_BillingId",
                table: "BillingLines");

            migrationBuilder.AlterColumn<string>(
                name: "BillingId",
                table: "Products",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BillingId1",
                table: "BillingLines",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Billing",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_BillingId1",
                table: "BillingLines",
                column: "BillingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Billing_BillingId1",
                table: "BillingLines",
                column: "BillingId1",
                principalTable: "Billing",
                principalColumn: "Id");
        }
    }
}
