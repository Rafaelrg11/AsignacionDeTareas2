using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AsignacionDeTareas2.Migrations
{
    public class UpdateDbProyects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proyects_tasks_idTasks",
                table: "proyects");

            migrationBuilder.DropIndex(
                name: "IX_proyects_idTasks",
                table: "proyects");

            migrationBuilder.DropColumn(
                name: "idTasks",
                table: "proyects");

            migrationBuilder.AlterColumn<int>(
                name: "idTask",
                table: "tasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "idProyect",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "idNotification",
                table: "notifications",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "idUSer",
                table: "notifications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "idComment",
                table: "comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "idTask",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Comments",
                table: "comments",
                column: "idComment",
                principalTable: "tasks",
                principalColumn: "idTask",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User",
                table: "notifications",
                column: "idNotification",
                principalTable: "users",
                principalColumn: "idUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks",
                column: "idTask",
                principalTable: "proyects",
                principalColumn: "idProyect",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Comments",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "idProyect",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "idUSer",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "idTask",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "idTask",
                table: "tasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "idTasks",
                table: "proyects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "idNotification",
                table: "notifications",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "idComment",
                table: "comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_proyects_idTasks",
                table: "proyects",
                column: "idTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_proyects_tasks_idTasks",
                table: "proyects",
                column: "idTasks",
                principalTable: "tasks",
                principalColumn: "idTask",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
