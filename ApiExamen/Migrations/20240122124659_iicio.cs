using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExamen.Migrations
{
    /// <inheritdoc />
    public partial class iicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tareas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "ID", "Estado", "Nombre", "Tareas" },
                values: new object[] { 1, "Por hacer", "Camila", "Acabar la API" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");
        }
    }
}
