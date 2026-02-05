using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioSpedy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinishedDateTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_UserId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ticket",
                newName: "ResponsableUserId");

            migrationBuilder.RenameColumn(
                name: "ClosedAt",
                table: "Ticket",
                newName: "FinishedAt");

            migrationBuilder.RenameColumn(
                name: "AssignedUserId",
                table: "Ticket",
                newName: "CreatorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                newName: "IX_Ticket_ResponsableUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CreatorUserId",
                table: "Ticket",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_CreatorUserId",
                table: "Ticket",
                column: "CreatorUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_ResponsableUserId",
                table: "Ticket",
                column: "ResponsableUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_CreatorUserId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_ResponsableUserId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CreatorUserId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "ResponsableUserId",
                table: "Ticket",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FinishedAt",
                table: "Ticket",
                newName: "ClosedAt");

            migrationBuilder.RenameColumn(
                name: "CreatorUserId",
                table: "Ticket",
                newName: "AssignedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ResponsableUserId",
                table: "Ticket",
                newName: "IX_Ticket_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
