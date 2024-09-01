using Microsoft.EntityFrameworkCore.Migrations;

namespace AsignacionDeTareas2.Migrations
{
    public class stateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "proyects");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "tasks",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "state",
                table: "tasks");

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "proyects",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }
    }
}
