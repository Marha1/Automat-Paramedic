using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automat_Paramedic.Migrations
{
    /// <inheritdoc />
    public partial class change_med : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Medicines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Medicines");
        }
    }
}
