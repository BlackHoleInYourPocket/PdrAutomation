﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework;

namespace PdrAutomate.WebUI.Migrations
{
    [DbContext(typeof(PdrAutomateContext))]
    partial class PdrAutomateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerName");

                    b.HasKey("AnswerId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassCapacity");

                    b.Property<string>("ClassName");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.ClassPresentationsession", b =>
                {
                    b.Property<int>("ClassId");

                    b.Property<int>("PresentationId");

                    b.Property<int>("SessionId");

                    b.Property<int>("CurrentCapacity");

                    b.HasKey("ClassId", "PresentationId", "SessionId");

                    b.HasIndex("PresentationId");

                    b.HasIndex("SessionId");

                    b.ToTable("ClassPresentationsessions");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Presentation", b =>
                {
                    b.Property<int>("PresentationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PresentationName");

                    b.HasKey("PresentationId");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.PresentationSession", b =>
                {
                    b.Property<int>("PresentationID");

                    b.Property<int>("SessionId");

                    b.HasKey("PresentationID", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("PresentationSessions");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCheckbox");

                    b.Property<string>("QuestionName");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Questionnarie", b =>
                {
                    b.Property<int>("QuestionnarieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSentiment");

                    b.Property<string>("QuestionnarieName");

                    b.HasKey("QuestionnarieId");

                    b.ToTable("Questionnaries");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.QuestionnarieQuestion", b =>
                {
                    b.Property<int>("QuestionnarieId");

                    b.Property<int>("QuestionId");

                    b.HasKey("QuestionnarieId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionnarieQuestions");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Sessions", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("SessionId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId");

                    b.Property<string>("Password");

                    b.Property<string>("StudentName");

                    b.Property<string>("StudentSchoolId");

                    b.Property<string>("StudentSurname");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.StudentPresentationQuestionnarieSession", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("PresentationId");

                    b.Property<int>("QuestionnarieId");

                    b.Property<int>("SessionId");

                    b.HasKey("StudentId", "PresentationId", "QuestionnarieId", "SessionId");

                    b.HasIndex("PresentationId");

                    b.HasIndex("QuestionnarieId");

                    b.HasIndex("SessionId");

                    b.ToTable("StudentPresentationQuestionnarieSessions");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.StudentPresentationsession", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("PresentationId");

                    b.Property<int>("SessionId");

                    b.HasKey("StudentId", "PresentationId", "SessionId");

                    b.HasIndex("PresentationId");

                    b.HasIndex("SessionId");

                    b.ToTable("StudentPresentationsessions");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.StudentQuestionnarieQuestionAnswer", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("QuestionnarieId");

                    b.Property<int>("AnswerId");

                    b.Property<int>("QuestionId");

                    b.HasKey("StudentId", "QuestionnarieId", "AnswerId", "QuestionId");

                    b.HasIndex("AnswerId")
                        .IsUnique();

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.HasIndex("QuestionnarieId");

                    b.ToTable("StudentQuestionnarieQuestionAnswers");
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.ClassPresentationsession", b =>
                {
                    b.HasOne("PdrAutomate.WebUI.Entity.Class", "Class")
                        .WithMany("ClassPresentationsessions")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Presentation", "Presentation")
                        .WithMany("ClassPresentationsessions")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Sessions", "Sessions")
                        .WithMany("ClassPresentationsessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.PresentationSession", b =>
                {
                    b.HasOne("PdrAutomate.WebUI.Entity.Presentation", "Presentation")
                        .WithMany("Sessions")
                        .HasForeignKey("PresentationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Sessions", "Sessions")
                        .WithMany("Presentations")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.QuestionnarieQuestion", b =>
                {
                    b.HasOne("PdrAutomate.WebUI.Entity.Question", "Question")
                        .WithMany("QuestionnarieQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Questionnarie", "Questionnarie")
                        .WithMany("QuestionnarieQuestions")
                        .HasForeignKey("QuestionnarieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.Student", b =>
                {
                    b.HasOne("PdrAutomate.WebUI.Entity.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.StudentPresentationQuestionnarieSession", b =>
                {
                    b.HasOne("PdrAutomate.WebUI.Entity.Presentation", "Presentation")
                        .WithMany("StudentPresentationQuestionnaries")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Questionnarie", "Questionnarie")
                        .WithMany("StudentPresentationQuestionnaries")
                        .HasForeignKey("QuestionnarieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Sessions", "Session")
                        .WithMany("StudentPresentationQuestionnarieSessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Student", "Student")
                        .WithMany("StudentPresentationQuestionnaries")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.StudentPresentationsession", b =>
                {
                    b.HasOne("PdrAutomate.WebUI.Entity.Presentation", "Presentation")
                        .WithMany("StudentPresentationsessions")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Sessions", "Sessions")
                        .WithMany("StudentPresentationsessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Student", "Student")
                        .WithMany("StudentPresentationsessions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PdrAutomate.WebUI.Entity.StudentQuestionnarieQuestionAnswer", b =>
                {
                    b.HasOne("PdrAutomate.WebUI.Entity.Answer", "Answer")
                        .WithOne("StudentQuestionnarieQuestionAnswers")
                        .HasForeignKey("PdrAutomate.WebUI.Entity.StudentQuestionnarieQuestionAnswer", "AnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Question", "Question")
                        .WithOne("StudentQuestionnarieQuestionAnswers")
                        .HasForeignKey("PdrAutomate.WebUI.Entity.StudentQuestionnarieQuestionAnswer", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Questionnarie", "Questionnarie")
                        .WithMany("StudentQuestionnarieQuestionAnswers")
                        .HasForeignKey("QuestionnarieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PdrAutomate.WebUI.Entity.Student", "Student")
                        .WithMany("StudentQuestionnarieQuestionAnswers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
