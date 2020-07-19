using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregatorContext.Migrations
{
    public partial class Links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "absURI",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Absuri",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "absURI",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Absuri",
                table: "Comments");
        }
    }
}
