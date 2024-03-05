﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationIdentity.Data;

#nullable disable

namespace WebApplicationIdentity.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240219133043_resumeUpload")]
    partial class resumeUpload
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.AddJobs", b =>
                {
                    b.Property<string>("Job_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<double?>("CTC")
                        .HasColumnType("double");

                    b.Property<string>("Company_Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Grad_cri")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("_10_cri")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("_12_cri")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Job_Id");

                    b.HasIndex("Company_Id")
                        .IsUnique();

                    b.ToTable("AddJobs");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Company", b =>
                {
                    b.Property<string>("Company_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Company_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contact_No")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.Property<string>("nameOfRepresentative")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Company_Id");

                    b.HasIndex("User_id")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.EducationModel", b =>
                {
                    b.Property<string>("StudentEducation_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Class10_Passing_Year")
                        .HasColumnType("int");

                    b.Property<double>("Class10_Percentage")
                        .HasColumnType("double");

                    b.Property<int>("Class12_Passing_Year")
                        .HasColumnType("int");

                    b.Property<double>("Class12_Percentage")
                        .HasColumnType("double");

                    b.Property<int>("Graduation_Completion_Year")
                        .HasColumnType("int");

                    b.Property<double>("Graduation_Percentage")
                        .HasColumnType("double");

                    b.Property<string>("Student_Id")
                        .HasColumnType("varchar(255)");

                    b.HasKey("StudentEducation_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("EducationModel");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Placement", b =>
                {
                    b.Property<string>("Placement_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Placement_Company")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Placement_Salary")
                        .HasColumnType("double");

                    b.Property<string>("Placement_Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Student_Id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Placement_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("placements");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ResumeFilePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StudentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationIdentity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.AddJobs", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.Company", "Company")
                        .WithOne("addjob")
                        .HasForeignKey("WebApplicationIdentity.Models.AddJobs", "Company_Id");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Company", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.ApplicationUser", "User")
                        .WithOne("Company")
                        .HasForeignKey("WebApplicationIdentity.Models.Company", "User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.EducationModel", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Placement", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Student", b =>
                {
                    b.HasOne("WebApplicationIdentity.Models.ApplicationUser", "User")
                        .WithOne("Student")
                        .HasForeignKey("WebApplicationIdentity.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.ApplicationUser", b =>
                {
                    b.Navigation("Company")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationIdentity.Models.Company", b =>
                {
                    b.Navigation("addjob");
                });
#pragma warning restore 612, 618
        }
    }
}
