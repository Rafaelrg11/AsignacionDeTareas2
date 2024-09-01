using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AsignacionDeTareas2.Migrations
{
    public class xddddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User",
                table: "notifications");

            migrationBuilder.AlterColumn<int>(
                name: "idNotification",
                table: "notifications",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_idUSer",
                table: "notifications",
                column: "idUSer");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User",
                table: "notifications",
                column: "idUSer",
                principalTable: "users",
                principalColumn: "idUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_idUSer",
                table: "notifications");

            migrationBuilder.AlterColumn<int>(
                name: "idNotification",
                table: "notifications",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User",
                table: "notifications",
                column: "idNotification",
                principalTable: "users",
                principalColumn: "idUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
