using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregatorContext.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthor_Authors_AuthorID",
                table: "ArticleAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthor_Posts_PostID",
                table: "ArticleAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Categories_CategoryID",
                table: "ArticleCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Posts_PostID",
                table: "ArticleCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleAuthor",
                table: "ArticleAuthor");

            migrationBuilder.RenameTable(
                name: "ArticleCategory",
                newName: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "ArticleAuthor",
                newName: "ArticleAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategory_CategoryID",
                table: "ArticleCategories",
                newName: "IX_ArticleCategories_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleAuthor_AuthorID",
                table: "ArticleAuthors",
                newName: "IX_ArticleAuthors_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories",
                columns: new[] { "PostID", "CategoryID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleAuthors",
                table: "ArticleAuthors",
                columns: new[] { "PostID", "AuthorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthors_Authors_AuthorID",
                table: "ArticleAuthors",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthors_Posts_PostID",
                table: "ArticleAuthors",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Categories_CategoryID",
                table: "ArticleCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Posts_PostID",
                table: "ArticleCategories",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthors_Authors_AuthorID",
                table: "ArticleAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleAuthors_Posts_PostID",
                table: "ArticleAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Categories_CategoryID",
                table: "ArticleCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Posts_PostID",
                table: "ArticleCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleAuthors",
                table: "ArticleAuthors");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                newName: "ArticleCategory");

            migrationBuilder.RenameTable(
                name: "ArticleAuthors",
                newName: "ArticleAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleCategories_CategoryID",
                table: "ArticleCategory",
                newName: "IX_ArticleCategory_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleAuthors_AuthorID",
                table: "ArticleAuthor",
                newName: "IX_ArticleAuthor_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory",
                columns: new[] { "PostID", "CategoryID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleAuthor",
                table: "ArticleAuthor",
                columns: new[] { "PostID", "AuthorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthor_Authors_AuthorID",
                table: "ArticleAuthor",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleAuthor_Posts_PostID",
                table: "ArticleAuthor",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Categories_CategoryID",
                table: "ArticleCategory",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Posts_PostID",
                table: "ArticleCategory",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
