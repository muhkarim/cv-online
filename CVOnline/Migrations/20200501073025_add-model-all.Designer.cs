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
    [Migration("20200501073025_add-model-all")]
    partial class addmodelall
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CVOnline.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PlaceOfBirth");

                    b.Property<string>("Religion");

                    b.Property<int>("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("User_Id")
                        .IsUnique();

                    b.ToTable("TB_M_Admin");
                });

            modelBuilder.Entity("CVOnline.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Biodata_Id");

                    b.Property<int>("Document_Id");

                    b.Property<int>("EducationalDetails_Id");

                    b.Property<int>("User_Id");

                    b.Property<int>("WorkExperience_Id");

                    b.HasKey("Id");

                    b.HasIndex("Biodata_Id")
                        .IsUnique();

                    b.HasIndex("Document_Id")
                        .IsUnique();

                    b.HasIndex("EducationalDetails_Id")
                        .IsUnique();

                    b.HasIndex("User_Id")
                        .IsUnique();

                    b.HasIndex("WorkExperience_Id")
                        .IsUnique();

                    b.ToTable("TB_M_Applicants");
                });

            modelBuilder.Entity("CVOnline.Models.Biodata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("IdCard");

                    b.Property<string>("LastName");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PlaceOfDate");

                    b.Property<string>("Religion");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Biodata");
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

            modelBuilder.Entity("CVOnline.Models.EducationalDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FinalValue");

                    b.Property<string>("GraduationYear");

                    b.Property<string>("Level");

                    b.Property<string>("Majors");

                    b.Property<string>("Name");

                    b.Property<string>("Place");

                    b.Property<string>("YearOfEntry");

                    b.HasKey("Id");

                    b.ToTable("TB_M_EducationalDetails");
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

            modelBuilder.Entity("CVOnline.Models.RequestApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<int?>("JobsId");

                    b.Property<int>("Jobs_Id");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("JobsId");

                    b.ToTable("TB_T_RequestApplication");
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

            modelBuilder.Entity("CVOnline.Models.UserRequest", b =>
                {
                    b.Property<int>("Applicants_Id");

                    b.Property<int>("RequestApplication_Id");

                    b.Property<int>("Id");

                    b.HasKey("Applicants_Id", "RequestApplication_Id");

                    b.HasAlternateKey("Id");

                    b.HasIndex("RequestApplication_Id");

                    b.ToTable("TB_T_UserRequest");
                });

            modelBuilder.Entity("CVOnline.Models.UserRole", b =>
                {
                    b.Property<int>("User_Id");

                    b.Property<int>("Role_Id");

                    b.HasKey("User_Id", "Role_Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("TB_M_UserRole");
                });

            modelBuilder.Entity("CVOnline.Models.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<string>("LastPosition");

                    b.Property<string>("LastSalary");

                    b.Property<string>("TypeOfBussiness");

                    b.Property<string>("YearOfResign");

                    b.Property<string>("YearStartedWorking");

                    b.HasKey("Id");

                    b.ToTable("TB_M_WorkExperience");
                });

            modelBuilder.Entity("CVOnline.Models.Admin", b =>
                {
                    b.HasOne("CVOnline.Models.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("CVOnline.Models.Admin", "User_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVOnline.Models.Applicant", b =>
                {
                    b.HasOne("CVOnline.Models.Biodata", "Biodata")
                        .WithOne("Applicant")
                        .HasForeignKey("CVOnline.Models.Applicant", "Biodata_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVOnline.Models.Document", "Document")
                        .WithOne("Applicant")
                        .HasForeignKey("CVOnline.Models.Applicant", "Document_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVOnline.Models.EducationalDetails", "EducationalDetails")
                        .WithOne("Applicant")
                        .HasForeignKey("CVOnline.Models.Applicant", "EducationalDetails_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVOnline.Models.User", "User")
                        .WithOne("Applicant")
                        .HasForeignKey("CVOnline.Models.Applicant", "User_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVOnline.Models.WorkExperience", "WorkExperience")
                        .WithOne("Applicant")
                        .HasForeignKey("CVOnline.Models.Applicant", "WorkExperience_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CVOnline.Models.RequestApplication", b =>
                {
                    b.HasOne("CVOnline.Models.Job", "Jobs")
                        .WithMany()
                        .HasForeignKey("JobsId");
                });

            modelBuilder.Entity("CVOnline.Models.UserRequest", b =>
                {
                    b.HasOne("CVOnline.Models.Applicant", "Applicant")
                        .WithMany("UserRequests")
                        .HasForeignKey("Applicants_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CVOnline.Models.RequestApplication", "RequestApplication")
                        .WithMany("UserRequests")
                        .HasForeignKey("RequestApplication_Id")
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