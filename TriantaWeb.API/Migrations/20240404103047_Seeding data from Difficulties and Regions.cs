using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TriantaWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdatafromDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("783492c2-549b-4ca6-a3f4-e7d4c137aafb"), "Hard" },
                    { new Guid("aa83b59b-5f54-45d9-96f0-351f61d6f81d"), "Easy" },
                    { new Guid("e9713023-05f6-4267-9e6b-ef3a6050fc28"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1324eb0d-ac35-4c5d-8116-7ff6500f0a4d"), "AML", "AMLAND", null },
                    { new Guid("2a1c6a17-0a84-45f0-926e-92c12d36a0e9"), "ACK", "ACKLAND", null },
                    { new Guid("687cbfce-4fa3-44b6-a18e-82de26e4859b"), "EK", "EKLAND", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("783492c2-549b-4ca6-a3f4-e7d4c137aafb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("aa83b59b-5f54-45d9-96f0-351f61d6f81d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e9713023-05f6-4267-9e6b-ef3a6050fc28"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1324eb0d-ac35-4c5d-8116-7ff6500f0a4d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2a1c6a17-0a84-45f0-926e-92c12d36a0e9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("687cbfce-4fa3-44b6-a18e-82de26e4859b"));
        }
    }
}
