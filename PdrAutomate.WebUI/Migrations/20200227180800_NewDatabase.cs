using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdrAutomate.WebUI.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentationClass");

            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropTable(
                name: "StudentPresentation");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentSurname",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    PresentationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresentationSessions",
                columns: table => new
                {
                    PresentationSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PresentationID = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationSessions", x => x.PresentationSessionId);
                    table.ForeignKey(
                        name: "FK_PresentationSessions_Presentations_PresentationID",
                        column: x => x.PresentationID,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentationSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassPresentationsessions",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    PresentationsessionId = table.Column<int>(nullable: false),
                    CurrentCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPresentationsessions", x => new { x.ClassId, x.PresentationsessionId });
                    table.ForeignKey(
                        name: "FK_ClassPresentationsessions_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassPresentationsessions_PresentationSessions_PresentationsessionId",
                        column: x => x.PresentationsessionId,
                        principalTable: "PresentationSessions",
                        principalColumn: "PresentationSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPresentationsessions",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    PresentationSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPresentationsessions", x => new { x.StudentId, x.PresentationSessionId });
                    table.ForeignKey(
                        name: "FK_StudentPresentationsessions_PresentationSessions_PresentationSessionId",
                        column: x => x.PresentationSessionId,
                        principalTable: "PresentationSessions",
                        principalColumn: "PresentationSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPresentationsessions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPresentationsessions_PresentationsessionId",
                table: "ClassPresentationsessions",
                column: "PresentationsessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationSessions_PresentationID",
                table: "PresentationSessions",
                column: "PresentationID");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationSessions_SessionId",
                table: "PresentationSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_PresentationId",
                table: "Sessions",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentationsessions_PresentationSessionId",
                table: "StudentPresentationsessions",
                column: "PresentationSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ClassPresentationsessions");

            migrationBuilder.DropTable(
                name: "StudentPresentationsessions");

            migrationBuilder.DropTable(
                name: "PresentationSessions");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentSurname",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "PresentationClass",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    CurrentCapacity = table.Column<int>(nullable: false),
                    Section = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationClass", x => new { x.PresentationId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_PresentationClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentationClass_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_StudentClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClass_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPresentation",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPresentation", x => new { x.StudentId, x.PresentationId });
                    table.ForeignKey(
                        name: "FK_StudentPresentation_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPresentation_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresentationClass_ClassId",
                table: "PresentationClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassId",
                table: "StudentClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_StudentId",
                table: "StudentClass",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentation_PresentationId",
                table: "StudentPresentation",
                column: "PresentationId");
        }
    }
}
