using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TriantaWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDesctiption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

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
    }
}
