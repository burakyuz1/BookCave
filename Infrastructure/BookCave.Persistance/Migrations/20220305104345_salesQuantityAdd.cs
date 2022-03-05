using Microsoft.EntityFrameworkCore.Migrations;

namespace BookCave.Persistance.Migrations
{
    public partial class salesQuantityAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesQuantity",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesQuantity",
                table: "Books");
        }
    }
}
