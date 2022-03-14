using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Velocity = table.Column<double>(type: "float(25)", precision: 25, scale: 2, nullable: false),
                    Mass = table.Column<double>(type: "float(25)", precision: 25, scale: 2, nullable: false),
                    Energy = table.Column<double>(type: "float(25)", precision: 25, scale: 2, nullable: false),
                    ImpactResult = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
