using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agile.Data.Migrations
{
    /// <inheritdoc />
    public partial class madeBoxEntityUserIdnullable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Boxes_InboxId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_InboxId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InboxId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InboxId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_InboxId",
                table: "Users",
                column: "InboxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Boxes_InboxId",
                table: "Users",
                column: "InboxId",
                principalTable: "Boxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
