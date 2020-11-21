using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalProject.Data.Migrations
{
    public partial class newdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiquidReagents");

            migrationBuilder.DropTable(
                name: "SolidReagents");

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reagents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Alert = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    stateId = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    MaxVolume = table.Column<int>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reagents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reagents_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reagents_State_stateId",
                        column: x => x.stateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Liquid" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Solid" });

            migrationBuilder.InsertData(
                table: "Reagents",
                columns: new[] { "Id", "Alert", "Location", "MaxVolume", "Name", "SupplierID", "Volume", "stateId" },
                values: new object[,]
                {
                    { 1, 4, "Cut-Up/Corrosive Cab", 2500, "Acetic Acid", 1, 2500, 1 },
                    { 2, 3, "Cut-Up/Corrosive Cab", 2500, "Ammonia", 2, 2500, 1 },
                    { 3, 1, "Specials cupboard", 25, "Alcian Blue", 1, 25, 2 },
                    { 4, 2, "Specials Cupboard", 500, "Ammonium iron sulphate", 2, 500, 2 },
                    { 5, 1, "Specials Cupboard", 25, "Aniline Blue", 3, 25, 2 },
                    { 6, 3, "Specials Cupboard", 1000, "Calcium Chloride", 4, 1000, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reagents_SupplierID",
                table: "Reagents",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Reagents_stateId",
                table: "Reagents",
                column: "stateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reagents");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.CreateTable(
                name: "LiquidReagents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertCode = table.Column<int>(type: "int", nullable: false),
                    LocationInLab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxVolume = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    currentVolume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidReagents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LiquidReagents_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolidReagents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertCode = table.Column<int>(type: "int", nullable: false),
                    LocationInLab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxVolume = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    currentVolume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolidReagents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SolidReagents_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LiquidReagents",
                columns: new[] { "ID", "AlertCode", "LocationInLab", "MaxVolume", "Name", "SupplierID", "currentVolume" },
                values: new object[,]
                {
                    { 1, 4, "Cut-Up/Corrosive Cab", 2500, "Acetic Acid", 1, 2500 },
                    { 2, 3, "Cut-Up/Corrosive Cab", 2500, "Ammonia", 2, 2500 }
                });

            migrationBuilder.InsertData(
                table: "SolidReagents",
                columns: new[] { "ID", "AlertCode", "LocationInLab", "MaxVolume", "Name", "SupplierID", "currentVolume" },
                values: new object[,]
                {
                    { 1, 1, "Specials cupboard", 25, "Alcian Blue", 1, 25 },
                    { 2, 2, "Specials Cupboard", 500, "Ammonium iron sulphate", 2, 500 },
                    { 3, 1, "Specials Cupboard", 25, "Aniline Blue", 3, 25 },
                    { 4, 3, "Specials Cupboard", 1000, "Calcium Chloride", 4, 1000 }
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
    }
}
