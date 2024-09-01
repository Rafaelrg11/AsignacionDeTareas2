using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AsignacionDeTareas2.Migrations
{
    public class xdddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Comments",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "idComment",
                table: "comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_comments_idTask",
                table: "comments",
                column: "idTask");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Comments",
                table: "comments",
                column: "idTask",
                principalTable: "tasks",
                principalColumn: "idTask",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Comments",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_idTask",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "idComment",
                table: "comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Comments",
                table: "comments",
                column: "idComment",
                principalTable: "tasks",
                principalColumn: "idTask",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
