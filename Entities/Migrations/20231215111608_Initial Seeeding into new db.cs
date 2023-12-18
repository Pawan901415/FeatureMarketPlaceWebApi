using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeeedingintonewdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 16, 46, 8, 725, DateTimeKind.Local).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 16, 46, 8, 725, DateTimeKind.Local).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 16, 46, 8, 725, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 16, 46, 8, 725, DateTimeKind.Local).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 16, 46, 8, 725, DateTimeKind.Local).AddTicks(6109));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 19, 21, 25, 852, DateTimeKind.Local).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 19, 21, 25, 852, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 19, 21, 25, 852, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 19, 21, 25, 852, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "FeatureID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 11, 19, 21, 25, 852, DateTimeKind.Local).AddTicks(9910));
        }
    }
}
