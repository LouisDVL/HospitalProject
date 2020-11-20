using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalProject.Data.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquidReagents_Suppliers_SupplierID",
                table: "LiquidReagents");

            migrationBuilder.DropForeignKey(
                name: "FK_SolidReagents_Suppliers_SupplierID",
                table: "SolidReagents");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "SolidReagents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlertCode",
                table: "SolidReagents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "LiquidReagents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlertCode",
                table: "LiquidReagents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "ID", "Contact", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "09-271 6415", "21C Andromeda Crescent, East Tamaki, Auckland 2013", "Milton Adams" },
                    { 2, "0800 342 466", "33 Westpoint Drive, Hobsonville, Auckland 0618", "Scharlau" },
                    { 3, "0800 652 634", "Sylvia Park", "Roche" },
                    { 4, "9429033701356", "Minter Ellison Rudd Watts, 88 Shortland Street, Auckland Central, Auckland", "Ajax Chemicals" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidReagents_Suppliers_SupplierID",
                table: "LiquidReagents",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolidReagents_Suppliers_SupplierID",
                table: "SolidReagents",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquidReagents_Suppliers_SupplierID",
                table: "LiquidReagents");

            migrationBuilder.DropForeignKey(
                name: "FK_SolidReagents_Suppliers_SupplierID",
                table: "SolidReagents");

            migrationBuilder.DeleteData(
                table: "LiquidReagents",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LiquidReagents",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SolidReagents",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SolidReagents",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SolidReagents",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SolidReagents",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Suppliers");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "SolidReagents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AlertCode",
                table: "SolidReagents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "LiquidReagents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AlertCode",
                table: "LiquidReagents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidReagents_Suppliers_SupplierID",
                table: "LiquidReagents",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolidReagents_Suppliers_SupplierID",
                table: "SolidReagents",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
