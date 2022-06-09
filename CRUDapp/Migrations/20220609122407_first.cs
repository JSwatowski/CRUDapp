using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDapp.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    Text = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "UserName" },
                values: new object[] { 1, "Just some text1", "User1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "UserName" },
                values: new object[] { 2, "Just some text2", "User2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "UserName" },
                values: new object[] { 3, "Just some text3", "User3" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "UserName" },
                values: new object[] { 4, "Just some text4", "User4" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "UserName" },
                values: new object[] { 5, "Just some text5", "User5" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Text", "UserName" },
                values: new object[] { 6, "Just some text6", "User6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
