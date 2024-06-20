using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TriantaWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("15ea7d57-6a47-4577-ab93-9a41c223e98e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4f4e329e-858e-4606-a2b4-b2d0ac297269"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c9f84790-9b6c-4fc0-afff-cebe0aeef909"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6f9f0369-6a9b-42ab-a9d8-00c22d63f29d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("82db451d-d227-43fd-ba7f-61636bbc4b57"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d3f4b7ad-ca16-487d-93c9-128fda20b7a9"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("86e2caef-2fc6-428d-8f0d-c780a164f071"), "Medium" },
                    { new Guid("d6274d92-93a9-40ff-b6af-e3576d02fda5"), "Hard" },
                    { new Guid("ecdfaefa-765b-42c6-831e-f49e15268061"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2386e995-94bd-4e2f-88bf-0dc8f387b98b"), "ACK", "ACKLAND", null },
                    { new Guid("bddff020-f140-40c9-95f2-002cf59e1f88"), "AML", "AMLAND", null },
                    { new Guid("ec169bf2-38de-4f60-bb1e-08fd8651eb29"), "EK", "EKLAND", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("86e2caef-2fc6-428d-8f0d-c780a164f071"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d6274d92-93a9-40ff-b6af-e3576d02fda5"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ecdfaefa-765b-42c6-831e-f49e15268061"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2386e995-94bd-4e2f-88bf-0dc8f387b98b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bddff020-f140-40c9-95f2-002cf59e1f88"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ec169bf2-38de-4f60-bb1e-08fd8651eb29"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15ea7d57-6a47-4577-ab93-9a41c223e98e"), "Medium" },
                    { new Guid("4f4e329e-858e-4606-a2b4-b2d0ac297269"), "Hard" },
                    { new Guid("c9f84790-9b6c-4fc0-afff-cebe0aeef909"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("6f9f0369-6a9b-42ab-a9d8-00c22d63f29d"), "ACK", "ACKLAND", null },
                    { new Guid("82db451d-d227-43fd-ba7f-61636bbc4b57"), "EK", "EKLAND", null },
                    { new Guid("d3f4b7ad-ca16-487d-93c9-128fda20b7a9"), "AML", "AMLAND", null }
                });
        }
    }
}
