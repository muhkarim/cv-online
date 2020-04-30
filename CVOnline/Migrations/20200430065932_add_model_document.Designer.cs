﻿// <auto-generated />
using System;
using CVOnline.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CVOnline.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200430065932_add_model_document")]
    partial class add_model_document
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CVOnline.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Document_Id");

                    b.HasKey("Id");

                    b.HasIndex("Document_Id")
                        .IsUnique();

                    b.ToTable("TB_M_Applicants");
                });

            modelBuilder.Entity("CVOnline.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CV");

                    b.Property<string>("Certificate");

                    b.Property<string>("Diploma");

                    b.Property<string>("FamilyCard");

                    b.Property<string>("IdCard");

                    b.Property<string>("Resume");

                    b.Property<string>("Transcripts");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Document");
                });

            modelBuilder.Entity("CVOnline.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("DueDate");

                    b.Property<string>("JobName");

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Jobs");
                });

            modelBuilder.Entity("CVOnline.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Roles");
                });

            modelBuilder.Entity("CVOnline.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Users");
                });

            modelBuilder.Entity("CVOnline.Models.UserRole", b =>
                {
                    b.Property<int>("User_Id");

                    b.Property<int>("Role_Id");

                    b.HasKey("User_Id", "Role_Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("TB_M_UserRole");
                });

            modelBuilder.Entity("CVOnline.Models.Applicant", b =>
                {
                    b.HasOne("CVOnline.Models.Document", "Document")
                        .WithOne("Applicant")
                        .HasForeignKey("CVOnline.Models.Applicant", "Document_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVOnline.Models.UserRole", b =>
                {
                    b.HasOne("CVOnline.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVOnline.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
