using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recruitment_app.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Contents = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    BirthdayDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SecondarySkills = table.Column<string>(type: "text", nullable: true),
                    Experience = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "LanguageQuestion",
                columns: table => new
                {
                    LanguagesUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionsUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageQuestion", x => new { x.LanguagesUuid, x.QuestionsUuid });
                    table.ForeignKey(
                        name: "FK_LanguageQuestion_Languages_LanguagesUuid",
                        column: x => x.LanguagesUuid,
                        principalTable: "Languages",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageQuestion_Questions_QuestionsUuid",
                        column: x => x.QuestionsUuid,
                        principalTable: "Questions",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageUser",
                columns: table => new
                {
                    LanguagesUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageUser", x => new { x.LanguagesUuid, x.UserUuid });
                    table.ForeignKey(
                        name: "FK_LanguageUser_Languages_LanguagesUuid",
                        column: x => x.LanguagesUuid,
                        principalTable: "Languages",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageUser_Users_UserUuid",
                        column: x => x.UserUuid,
                        principalTable: "Users",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageQuestion_QuestionsUuid",
                table: "LanguageQuestion",
                column: "QuestionsUuid");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageUser_UserUuid",
                table: "LanguageUser",
                column: "UserUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageQuestion");

            migrationBuilder.DropTable(
                name: "LanguageUser");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
