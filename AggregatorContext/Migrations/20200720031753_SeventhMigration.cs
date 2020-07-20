using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregatorContext.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentatorComment_commentators_CommentatorID",
                table: "CommentatorComment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentatorComment_Comments_commentsCommentID",
                table: "CommentatorComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentatorComment",
                table: "CommentatorComment");

            migrationBuilder.RenameTable(
                name: "CommentatorComment",
                newName: "CommentatorComments");

            migrationBuilder.RenameIndex(
                name: "IX_CommentatorComment_commentsCommentID",
                table: "CommentatorComments",
                newName: "IX_CommentatorComments_commentsCommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentatorComments",
                table: "CommentatorComments",
                columns: new[] { "CommentatorID", "CommentID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentatorComments_commentators_CommentatorID",
                table: "CommentatorComments",
                column: "CommentatorID",
                principalTable: "commentators",
                principalColumn: "CommentatorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentatorComments_Comments_commentsCommentID",
                table: "CommentatorComments",
                column: "commentsCommentID",
                principalTable: "Comments",
                principalColumn: "CommentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentatorComments_commentators_CommentatorID",
                table: "CommentatorComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentatorComments_Comments_commentsCommentID",
                table: "CommentatorComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentatorComments",
                table: "CommentatorComments");

            migrationBuilder.RenameTable(
                name: "CommentatorComments",
                newName: "CommentatorComment");

            migrationBuilder.RenameIndex(
                name: "IX_CommentatorComments_commentsCommentID",
                table: "CommentatorComment",
                newName: "IX_CommentatorComment_commentsCommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentatorComment",
                table: "CommentatorComment",
                columns: new[] { "CommentatorID", "CommentID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentatorComment_commentators_CommentatorID",
                table: "CommentatorComment",
                column: "CommentatorID",
                principalTable: "commentators",
                principalColumn: "CommentatorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentatorComment_Comments_commentsCommentID",
                table: "CommentatorComment",
                column: "commentsCommentID",
                principalTable: "Comments",
                principalColumn: "CommentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
