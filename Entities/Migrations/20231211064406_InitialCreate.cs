using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 12, 14, 6, 520, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 12, 14, 6, 520, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 12, 14, 6, 520, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 12, 14, 6, 520, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 12, 14, 6, 520, DateTimeKind.Local).AddTicks(799));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 9, 18, 28, 13, 171, DateTimeKind.Local).AddTicks(7490));
        }
    }
}
