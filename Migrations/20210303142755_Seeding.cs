using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace labo02.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VaccinTypes",
                columns: new[] { "VaccinTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("e6ec5a6f-7db7-4cf7-8890-c062142af6c4"), "Pfizer" },
                    { new Guid("2f0428e2-083e-4e52-a4e0-8264656e13de"), "Spoetnik" }
                });

            migrationBuilder.InsertData(
                table: "VaccinationLocation",
                columns: new[] { "VaccinationLocationId", "Name" },
                values: new object[,]
                {
                    { new Guid("c6422b13-f0eb-449a-81bf-f7a20aa31a6a"), "Kortrijk Expo" },
                    { new Guid("e7c22b54-849e-4999-8d08-9731d8ab7db3"), "Gent Expo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VaccinTypes",
                keyColumn: "VaccinTypeId",
                keyValue: new Guid("2f0428e2-083e-4e52-a4e0-8264656e13de"));

            migrationBuilder.DeleteData(
                table: "VaccinTypes",
                keyColumn: "VaccinTypeId",
                keyValue: new Guid("e6ec5a6f-7db7-4cf7-8890-c062142af6c4"));

            migrationBuilder.DeleteData(
                table: "VaccinationLocation",
                keyColumn: "VaccinationLocationId",
                keyValue: new Guid("c6422b13-f0eb-449a-81bf-f7a20aa31a6a"));

            migrationBuilder.DeleteData(
                table: "VaccinationLocation",
                keyColumn: "VaccinationLocationId",
                keyValue: new Guid("e7c22b54-849e-4999-8d08-9731d8ab7db3"));
        }
    }
}
