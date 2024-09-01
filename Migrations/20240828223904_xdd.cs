using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AsignacionDeTareas2.Migrations
{
    public class xdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "idTask",
                table: "tasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_idProyect",
                table: "tasks",
                column: "idProyect");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks",
                column: "idProyect",
                principalTable: "proyects",
                principalColumn: "idProyect",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_idProyect",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "idTask",
                table: "tasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Comments",
                table: "tasks",
                column: "idTask",
                principalTable: "proyects",
                principalColumn: "idProyect",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
