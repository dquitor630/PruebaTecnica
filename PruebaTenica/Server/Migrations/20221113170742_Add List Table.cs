using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTenica.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "director",
                table: "Films",
                newName: "Director");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Director",
                table: "Films",
                newName: "director");
        }
    }
}
