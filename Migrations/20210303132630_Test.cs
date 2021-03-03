using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace labo02.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VaccinationLocation",
                columns: table => new
                {
                    VaccinationLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationLocation", x => x.VaccinationLocationId);
                });

            migrationBuilder.CreateTable(
                name: "VaccininationRegistration",
                columns: table => new
                {
                    VaccinationRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    VaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccininationRegistration", x => x.VaccinationRegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "VaccinTypes",
                columns: table => new
                {
                    VaccinTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinTypes", x => x.VaccinTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationLocation");

            migrationBuilder.DropTable(
                name: "VaccininationRegistration");

            migrationBuilder.DropTable(
                name: "VaccinTypes");
        }
    }
}
