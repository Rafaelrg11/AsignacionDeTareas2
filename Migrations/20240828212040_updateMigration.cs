using Microsoft.EntityFrameworkCore.Migrations;

namespace AsignacionDeTareas2.Migrations
{
    public class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Notification",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_idNotifi",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_tasks_idComments",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "idNotifi",
                table: "users");

            migrationBuilder.DropColumn(
                name: "idComments",
                table: "tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idNotifi",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idComments",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_idNotifi",
                table: "users",
                column: "idNotifi");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_idComments",
                table: "tasks",
                column: "idComments");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks",
                column: "idComments",
                principalTable: "comments",
                principalColumn: "idComment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Notification",
                table: "users",
                column: "idNotifi",
                principalTable: "notifications",
                principalColumn: "idNotification",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
