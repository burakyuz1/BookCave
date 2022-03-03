using Microsoft.EntityFrameworkCore.Migrations;

namespace BookCave.Persistance.Migrations
{
    public partial class somethingchange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CategoryDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
