using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automat_Paramedic.Migrations
{
    /// <inheritdoc />
    public partial class changeMedRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "MedicalRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "MedicalRecords",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
