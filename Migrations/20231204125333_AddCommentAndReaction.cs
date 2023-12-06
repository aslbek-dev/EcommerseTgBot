using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerseBot.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentAndReaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reaction",
                table: "Users",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reaction",
                table: "Users");
        }
    }
}
