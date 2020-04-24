using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdrAutomate.WebUI.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true),
                    ClassCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PresentationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.PresentationId);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaries",
                columns: table => new
                {
                    QuestionnarieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionnarieName = table.Column<string>(nullable: true),
                    IsSentiment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaries", x => x.QuestionnarieId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionName = table.Column<string>(nullable: true),
                    IsCheckbox = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentName = table.Column<string>(nullable: true),
                    StudentSurname = table.Column<string>(nullable: true),
                    StudentSchoolId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnarieQuestions",
                columns: table => new
                {
                    QuestionnarieId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnarieQuestions", x => new { x.QuestionnarieId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuestionnarieQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionnarieQuestions_Questionnaries_QuestionnarieId",
                        column: x => x.QuestionnarieId,
                        principalTable: "Questionnaries",
                        principalColumn: "QuestionnarieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassPresentationsessions",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    CurrentCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPresentationsessions", x => new { x.ClassId, x.PresentationId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_ClassPresentationsessions_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassPresentationsessions_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassPresentationsessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresentationSessions",
                columns: table => new
                {
                    PresentationID = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationSessions", x => new { x.PresentationID, x.SessionId });
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
                name: "StudentPresentationQuestionnarieSessions",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false),
                    QuestionnarieId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPresentationQuestionnarieSessions", x => new { x.StudentId, x.PresentationId, x.QuestionnarieId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_StudentPresentationQuestionnarieSessions_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPresentationQuestionnarieSessions_Questionnaries_QuestionnarieId",
                        column: x => x.QuestionnarieId,
                        principalTable: "Questionnaries",
                        principalColumn: "QuestionnarieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPresentationQuestionnarieSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPresentationQuestionnarieSessions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPresentationsessions",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPresentationsessions", x => new { x.StudentId, x.PresentationId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_StudentPresentationsessions_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPresentationsessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPresentationsessions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuestionnarieQuestionAnswers",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    QuestionnarieId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestionnarieQuestionAnswers", x => new { x.StudentId, x.QuestionnarieId, x.AnswerId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_StudentQuestionnarieQuestionAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnarieQuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnarieQuestionAnswers_Questionnaries_QuestionnarieId",
                        column: x => x.QuestionnarieId,
                        principalTable: "Questionnaries",
                        principalColumn: "QuestionnarieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnarieQuestionAnswers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassPresentationsessions_PresentationId",
                table: "ClassPresentationsessions",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPresentationsessions_SessionId",
                table: "ClassPresentationsessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationSessions_SessionId",
                table: "PresentationSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnarieQuestions_QuestionId",
                table: "QuestionnarieQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentationQuestionnarieSessions_PresentationId",
                table: "StudentPresentationQuestionnarieSessions",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentationQuestionnarieSessions_QuestionnarieId",
                table: "StudentPresentationQuestionnarieSessions",
                column: "QuestionnarieId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentationQuestionnarieSessions_SessionId",
                table: "StudentPresentationQuestionnarieSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentationsessions_PresentationId",
                table: "StudentPresentationsessions",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentationsessions_SessionId",
                table: "StudentPresentationsessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnarieQuestionAnswers_AnswerId",
                table: "StudentQuestionnarieQuestionAnswers",
                column: "AnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnarieQuestionAnswers_QuestionId",
                table: "StudentQuestionnarieQuestionAnswers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnarieQuestionAnswers_QuestionnarieId",
                table: "StudentQuestionnarieQuestionAnswers",
                column: "QuestionnarieId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassPresentationsessions");

            migrationBuilder.DropTable(
                name: "PresentationSessions");

            migrationBuilder.DropTable(
                name: "QuestionnarieQuestions");

            migrationBuilder.DropTable(
                name: "StudentPresentationQuestionnarieSessions");

            migrationBuilder.DropTable(
                name: "StudentPresentationsessions");

            migrationBuilder.DropTable(
                name: "StudentQuestionnarieQuestionAnswers");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Questionnaries");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
