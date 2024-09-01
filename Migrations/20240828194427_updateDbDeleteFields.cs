using Microsoft.EntityFrameworkCore.Migrations;

namespace AsignacionDeTareas2.Migrations
{
    public partial class updateDbDeleteFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auxiliart_Comment",
                table: "auxiliarT");

            migrationBuilder.DropForeignKey(
                name: "FK_Auxiliart_Notification",
                table: "auxiliarT");

            migrationBuilder.DropIndex(
                name: "IX_auxiliarT_idCommet",
                table: "auxiliarT");

            migrationBuilder.DropIndex(
                name: "IX_auxiliarT_idNotification",
                table: "auxiliarT");

            migrationBuilder.DropColumn(
                name: "idCommet",
                table: "auxiliarT");

            migrationBuilder.DropColumn(
                name: "idNotification",
                table: "auxiliarT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCommet",
                table: "auxiliarT",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idNotification",
                table: "auxiliarT",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_idCommet",
                table: "auxiliarT",
                column: "idCommet");

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_idNotification",
                table: "auxiliarT",
                column: "idNotification");

            migrationBuilder.AddForeignKey(
                name: "FK_Auxiliart_Comment",
                table: "auxiliarT",
                column: "idCommet",
                principalTable: "comments",
                principalColumn: "idComment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auxiliart_Notification",
                table: "auxiliarT",
                column: "idNotification",
                principalTable: "notifications",
                principalColumn: "idNotification",
                onDelete: ReferentialAction.Cascade);
        } 
    }    
}

