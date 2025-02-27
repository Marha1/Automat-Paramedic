using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Automat_Paramedic.Migrations
{
    /// <inheritdoc />
    public partial class change_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Symptoms = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Treatment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Recommendations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    MedicineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTransaction_MedicineId",
                table: "MedicineTransaction",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MedicineId",
                table: "Appointments",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineTransaction_Medicines_MedicineId",
                table: "MedicineTransaction",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineTransaction_Medicines_MedicineId",
                table: "MedicineTransaction");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_MedicineTransaction_MedicineId",
                table: "MedicineTransaction");
        }
    }
}
