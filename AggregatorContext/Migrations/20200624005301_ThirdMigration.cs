using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregatorContext.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Posts",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Lastupdated",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Posts",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "Authors",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorURI",
                table: "Authors",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleAuthor",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAuthor", x => new { x.PostID, x.AuthorID });
                    table.ForeignKey(
                        name: "FK_ArticleAuthor_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleAuthor_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => new { x.PostID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogID",
                table: "Posts",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAuthor_AuthorID",
                table: "ArticleAuthor",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_CategoryID",
                table: "ArticleCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogID",
                table: "Posts",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "ArticleAuthor");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Lastupdated",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AuthorURI",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
