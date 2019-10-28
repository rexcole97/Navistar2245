using Microsoft.EntityFrameworkCore.Migrations;

namespace NavistarGL.Migrations
{
    public partial class pages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(nullable: true),
                    Dlocation = table.Column<string>(nullable: true),
                    Dhead = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DID);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EFN = table.Column<string>(nullable: true),
                    ELN = table.Column<string>(nullable: true),
                    DID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EID);
                    table.ForeignKey(
                        name: "FK_employees_departments_DID",
                        column: x => x.DID,
                        principalTable: "departments",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_DID",
                table: "employees",
                column: "DID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
