using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Features");

            migrationBuilder.AlterColumn<string>(
                name: "AdminComments",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserName" },
                values: new object[] { new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7470), "pawan" });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserName" },
                values: new object[] { new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7486), "kunal" });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserName" },
                values: new object[] { new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7487), "kunal" });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserName" },
                values: new object[] { new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7489), "kunal" });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UserName" },
                values: new object[] { new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7490), "kunal" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Features");

            migrationBuilder.AlterColumn<string>(
                name: "AdminComments",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2738), 0 });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2752), 0 });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2754), 0 });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2797), 0 });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2799), 0 });
        }
    }
}
