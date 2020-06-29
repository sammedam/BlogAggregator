using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregatorContext.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommenterName",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "Commentator",
                columns: table => new
                {
                    CommentatorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentatorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentator", x => x.CommentatorID);
                });

            migrationBuilder.CreateTable(
                name: "CommentatorComment",
                columns: table => new
                {
                    CommentatorID = table.Column<int>(nullable: false),
                    CommentID = table.Column<int>(nullable: false),
                    commentsCommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentatorComment", x => new { x.CommentatorID, x.CommentID });
                    table.ForeignKey(
                        name: "FK_CommentatorComment_Commentator_CommentatorID",
                        column: x => x.CommentatorID,
                        principalTable: "Commentator",
                        principalColumn: "CommentatorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentatorComment_Comments_commentsCommentID",
                        column: x => x.commentsCommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentatorComment_commentsCommentID",
                table: "CommentatorComment",
                column: "commentsCommentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentatorComment");

            migrationBuilder.DropTable(
                name: "Commentator");

            migrationBuilder.AddColumn<string>(
                name: "CommenterName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
