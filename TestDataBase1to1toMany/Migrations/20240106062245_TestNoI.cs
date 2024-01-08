using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDataBase1to1toMany.Migrations
{
    /// <inheritdoc />
    public partial class TestNoI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
