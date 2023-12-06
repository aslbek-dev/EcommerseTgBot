using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerseBot.Migrations
{
    /// <inheritdoc />
    public partial class ChangingName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemType",
                table: "Products",
                newName: "productType");

            migrationBuilder.AlterColumn<int>(
                name: "Branch",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "productType",
                table: "Products",
                newName: "ItemType");

            migrationBuilder.AlterColumn<int>(
                name: "Branch",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
