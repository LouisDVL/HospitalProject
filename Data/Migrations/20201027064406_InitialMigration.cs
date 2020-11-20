using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalProject.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LiquidReagents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AlertCode = table.Column<string>(nullable: true),
                    LocationInLab = table.Column<string>(nullable: true),
                    currentVolume = table.Column<int>(nullable: false),
                    MaxVolume = table.Column<int>(nullable: false),
                    SupplierID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidReagents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LiquidReagents_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolidReagents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AlertCode = table.Column<string>(nullable: true),
                    LocationInLab = table.Column<string>(nullable: true),
                    currentVolume = table.Column<int>(nullable: false),
                    MaxVolume = table.Column<int>(nullable: false),
                    SupplierID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolidReagents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SolidReagents_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiquidReagents_SupplierID",
                table: "LiquidReagents",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SolidReagents_SupplierID",
                table: "SolidReagents",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiquidReagents");

            migrationBuilder.DropTable(
                name: "SolidReagents");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
