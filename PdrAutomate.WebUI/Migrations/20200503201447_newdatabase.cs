using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PdrAutomate.WebUI.Migrations
{
    public partial class newdatabase : Migration
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
                name: "BeierStudentQuestionnarieQuestionAnswers",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    QuestionnarieId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeierStudentQuestionnarieQuestionAnswers", x => new { x.StudentId, x.QuestionnarieId, x.AnswerId });
                    table.ForeignKey(
                        name: "FK_BeierStudentQuestionnarieQuestionAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeierStudentQuestionnarieQuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeierStudentQuestionnarieQuestionAnswers_Questionnaries_QuestionnarieId",
                        column: x => x.QuestionnarieId,
                        principalTable: "Questionnaries",
                        principalColumn: "QuestionnarieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeierStudentQuestionnarieQuestionAnswers_Students_StudentId",
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
                name: "StudentQuestionnariePresentationSessionQuestionAnswers",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    QuestionnarieId = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestionnariePresentationSessionQuestionAnswers", x => new { x.StudentId, x.QuestionnarieId, x.PresentationId, x.SessionId, x.AnswerId });
                    table.ForeignKey(
                        name: "FK_StudentQuestionnariePresentationSessionQuestionAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnariePresentationSessionQuestionAnswers_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnariePresentationSessionQuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnariePresentationSessionQuestionAnswers_Questionnaries_QuestionnarieId",
                        column: x => x.QuestionnarieId,
                        principalTable: "Questionnaries",
                        principalColumn: "QuestionnarieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnariePresentationSessionQuestionAnswers_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentQuestionnariePresentationSessionQuestionAnswers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeierStudentQuestionnarieQuestionAnswers_AnswerId",
                table: "BeierStudentQuestionnarieQuestionAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_BeierStudentQuestionnarieQuestionAnswers_QuestionId",
                table: "BeierStudentQuestionnarieQuestionAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BeierStudentQuestionnarieQuestionAnswers_QuestionnarieId",
                table: "BeierStudentQuestionnarieQuestionAnswers",
                column: "QuestionnarieId");

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
                name: "IX_StudentPresentationsessions_PresentationId",
                table: "StudentPresentationsessions",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresentationsessions_SessionId",
                table: "StudentPresentationsessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnariePresentationSessionQuestionAnswers_AnswerId",
                table: "StudentQuestionnariePresentationSessionQuestionAnswers",
                column: "AnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnariePresentationSessionQuestionAnswers_PresentationId",
                table: "StudentQuestionnariePresentationSessionQuestionAnswers",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnariePresentationSessionQuestionAnswers_QuestionId",
                table: "StudentQuestionnariePresentationSessionQuestionAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnariePresentationSessionQuestionAnswers_QuestionnarieId",
                table: "StudentQuestionnariePresentationSessionQuestionAnswers",
                column: "QuestionnarieId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionnariePresentationSessionQuestionAnswers_SessionId",
                table: "StudentQuestionnariePresentationSessionQuestionAnswers",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeierStudentQuestionnarieQuestionAnswers");

            migrationBuilder.DropTable(
                name: "ClassPresentationsessions");

            migrationBuilder.DropTable(
                name: "PresentationSessions");

            migrationBuilder.DropTable(
                name: "QuestionnarieQuestions");

            migrationBuilder.DropTable(
                name: "StudentPresentationsessions");

            migrationBuilder.DropTable(
                name: "StudentQuestionnariePresentationSessionQuestionAnswers");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Questionnaries");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
