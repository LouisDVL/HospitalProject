using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalProject.Data.Migrations
{
    public partial class changedtofloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Suppliers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "State",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Volume",
                table: "Reagents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reagents",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MaxVolume",
                table: "Reagents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Reagents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 2500f, 2500f });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 2500f, 2500f });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 25f, 25f });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 500f, 500f });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 25f, 25f });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 1000f, 1000f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "State",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Volume",
                table: "Reagents",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reagents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "MaxVolume",
                table: "Reagents",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Reagents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 2500, 2500 });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 2500, 2500 });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 500, 500 });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "Reagents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaxVolume", "Volume" },
                values: new object[] { 1000, 1000 });
        }
    }
}
