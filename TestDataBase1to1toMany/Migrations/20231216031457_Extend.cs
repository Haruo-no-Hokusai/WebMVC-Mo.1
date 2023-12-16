using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDataBase1to1toMany.Migrations
{
    /// <inheritdoc />
    public partial class Extend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductExtend_Color",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductExtend_Weight",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductExtend_Color",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductExtend_Weight",
                table: "Product");
        }
    }
}
