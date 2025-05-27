using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techan.Migrations
{
    /// <inheritdoc />
    public partial class updatedBrandsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoPath",
                table: "Brands",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Brands",
                newName: "LogoPath");
        }
    }
}
