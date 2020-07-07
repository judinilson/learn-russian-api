﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using learn_Russian_API.Presistence;

namespace learn_Russian_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("learn_Russian_API.Models.TeacherGroup.Create.TeacherGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("teaching_time")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.ToTable("TeacherGroups");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnswerTypes")
                        .HasColumnType("integer");

                    b.Property<string>("Answers")
                        .HasColumnType("text");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<long?>("TrainingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Content", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("article")
                        .HasColumnType("text");

                    b.Property<string>("author")
                        .HasColumnType("text");

                    b.Property<long>("categoryID")
                        .HasColumnType("bigint");

                    b.Property<string>("coverImage")
                        .HasColumnType("text");

                    b.Property<bool>("isArticle")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDemo")
                        .HasColumnType("boolean");

                    b.Property<string>("subtitle")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.DemostrationContents", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("ContentId")
                        .HasColumnType("bigint");

                    b.Property<string>("src")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("DemostrationContentses");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Statistic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BackToArticleCount")
                        .HasColumnType("integer");

                    b.Property<int>("TotalCorrectAnswers")
                        .HasColumnType("integer");

                    b.Property<int>("TotalIncorrectAnswers")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TrainingDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Training", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string[]>("Questions")
                        .HasColumnType("text[]");

                    b.Property<long?>("TrainingContentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TrainingContentId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.TrainingContent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TrainingContents");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<long?>("TeacherGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Answer", b =>
                {
                    b.HasOne("learn_Russian_API.Presistence.Entities.Training", null)
                        .WithMany("Answers")
                        .HasForeignKey("TrainingId");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.DemostrationContents", b =>
                {
                    b.HasOne("learn_Russian_API.Presistence.Entities.Content", null)
                        .WithMany("DemostrationContentses")
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Statistic", b =>
                {
                    b.HasOne("learn_Russian_API.Presistence.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("learn_Russian_API.Presistence.Entities.Training", b =>
                {
                    b.HasOne("learn_Russian_API.Presistence.Entities.TrainingContent", null)
                        .WithMany("Trainings")
                        .HasForeignKey("TrainingContentId");
                });
#pragma warning restore 612, 618
        }
    }
}
