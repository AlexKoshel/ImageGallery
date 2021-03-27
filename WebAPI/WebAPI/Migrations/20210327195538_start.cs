using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "galleries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    title = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    discription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    image = table.Column<byte[]>(type: "bytea", nullable: false),
                    galleryid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media", x => x.id);
                    table.ForeignKey(
                        name: "media_galleryid_fkey",
                        column: x => x.galleryid,
                        principalTable: "galleries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_media_galleryid",
                table: "media",
                column: "galleryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "media");

            migrationBuilder.DropTable(
                name: "galleries");
        }
    }
}
