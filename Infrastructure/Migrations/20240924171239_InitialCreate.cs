using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Identity.migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    ParentCategoryID = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Role = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: true),
                    Level = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Price = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: true, defaultValueSql: "0.00"),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true),
                    ThumbnailURL = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Language = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "Course_Content",
                columns: table => new
                {
                    ContentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Title = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Content", x => x.ContentID);
                    table.ForeignKey(
                        name: "FK_Course_Content_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Course_Materials",
                columns: table => new
                {
                    MaterialID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: true),
                    FilePath = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    FileType = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Materials", x => x.MaterialID);
                    table.ForeignKey(
                        name: "FK_Course_Materials_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Text_Contents",
                columns: table => new
                {
                    TextID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContentID = table.Column<int>(type: "INTEGER", nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Text_Contents", x => x.TextID);
                    table.ForeignKey(
                        name: "FK_Text_Contents_Course_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Course_Content",
                        principalColumn: "ContentID");
                });

            migrationBuilder.CreateTable(
                name: "Video_Contents",
                columns: table => new
                {
                    VideoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContentID = table.Column<int>(type: "INTEGER", nullable: true),
                    VideoURL = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video_Contents", x => x.VideoID);
                    table.ForeignKey(
                        name: "FK_Video_Contents_Course_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Course_Content",
                        principalColumn: "ContentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Content_CourseID",
                table: "Course_Content",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Materials_CourseID",
                table: "Course_Materials",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryID",
                table: "Courses",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Text_Contents_ContentID",
                table: "Text_Contents",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_Contents_ContentID",
                table: "Video_Contents",
                column: "ContentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course_Materials");

            migrationBuilder.DropTable(
                name: "Text_Contents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Video_Contents");

            migrationBuilder.DropTable(
                name: "Course_Content");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
