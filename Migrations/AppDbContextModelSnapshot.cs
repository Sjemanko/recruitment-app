﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using recruitment_app.Data;

#nullable disable

namespace recruitment_app.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LanguageQuestion", b =>
                {
                    b.Property<Guid>("LanguagesUuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionsUuid")
                        .HasColumnType("uuid");

                    b.HasKey("LanguagesUuid", "QuestionsUuid");

                    b.HasIndex("QuestionsUuid");

                    b.ToTable("LanguageQuestion");
                });

            modelBuilder.Entity("LanguageUser", b =>
                {
                    b.Property<Guid>("LanguagesUuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserUuid")
                        .HasColumnType("uuid");

                    b.HasKey("LanguagesUuid", "UserUuid");

                    b.HasIndex("UserUuid");

                    b.ToTable("LanguageUser");
                });

            modelBuilder.Entity("recruitment_app.Models.Language", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Uuid");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("recruitment_app.Models.Question", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contents")
                        .HasColumnType("text");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Uuid");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("recruitment_app.Models.User", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("BirthdayDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Experience")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecondarySkills")
                        .HasColumnType("text");

                    b.Property<DateOnly>("UpdatedAt")
                        .HasColumnType("date");

                    b.HasKey("Uuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LanguageQuestion", b =>
                {
                    b.HasOne("recruitment_app.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recruitment_app.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageUser", b =>
                {
                    b.HasOne("recruitment_app.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recruitment_app.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
