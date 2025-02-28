using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Automat_Paramedic.Migrations
{
    /// <inheritdoc />
    public partial class addVaccin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VaccinationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    VaccineName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    VaccinationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NextVaccinationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationRecords");
        }
    }
}
