using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregatorContext.Migrations
{
    public partial class Reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PCID",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PCID",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropColumn(
                name: "PCID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PCID",
                table: "Comments");
        }
    }
}
