using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudShopApp.Migrations
{
    /// <inheritdoc />
    public partial class Productsupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderComponents",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderComponents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clients",
                newName: "Id");
        }
    }
}
