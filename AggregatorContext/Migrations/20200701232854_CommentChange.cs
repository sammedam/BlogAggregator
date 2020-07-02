using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregatorContext.Migrations
{
    public partial class CommentChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentatorComment_Commentator_CommentatorID",
                table: "CommentatorComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commentator",
                table: "Commentator");

            migrationBuilder.RenameTable(
                name: "Commentator",
                newName: "commentators");

            migrationBuilder.AlterColumn<string>(
                name: "CommentPosted",
                table: "Comments",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commentatoremail",
                table: "commentators",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_commentators",
                table: "commentators",
                column: "CommentatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentatorComment_commentators_CommentatorID",
                table: "CommentatorComment",
                column: "CommentatorID",
                principalTable: "commentators",
                principalColumn: "CommentatorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentatorComment_commentators_CommentatorID",
                table: "CommentatorComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_commentators",
                table: "commentators");

            migrationBuilder.DropColumn(
                name: "Commentatoremail",
                table: "commentators");

            migrationBuilder.RenameTable(
                name: "commentators",
                newName: "Commentator");

            migrationBuilder.AlterColumn<string>(
                name: "CommentPosted",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commentator",
                table: "Commentator",
                column: "CommentatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentatorComment_Commentator_CommentatorID",
                table: "CommentatorComment",
                column: "CommentatorID",
                principalTable: "Commentator",
                principalColumn: "CommentatorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
