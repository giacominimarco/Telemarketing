using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telemarketing.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeCalcToIndicator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeCalc",
                table: "Indicators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeCalc",
                table: "Indicators");
        }
    }
}
