﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanningParadiseAdmin.Data;

namespace PlanningParadiseAdmin.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220101093651_wwaimages")]
    partial class wwaimages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasMaxLength(250)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("Modified")
                        .HasMaxLength(250)
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.AboutUs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Para1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Para2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Para3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Qoute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Banner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutBanner_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutBanner_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogBanner_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogBanner_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactBanner_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactBanner_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationBanner_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationBanner_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaqBanner_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaqBanner_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GalleryBanner_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GalleryBanner_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceBanner_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceBanner_Img")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogLong_Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogShort_Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Blog_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Blog_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.DestinationWedding", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destination_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInterNational")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNational")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("DestinationWedding");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.FAQ", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Faq_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faq_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Gallery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gallery_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gallery_Video")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("WWA_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Img9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWA_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Welcome_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Welcome_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Home");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Services", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Service_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Servie_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Slider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Slider_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slider_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slider_Order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slider_SubHead")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designatin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAcctive")
                        .HasColumnType("bit");

                    b.Property<string>("Member_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.Testimonial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAvtive")
                        .HasColumnType("bit");

                    b.Property<string>("Testimonial_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Testimonial_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Testimonial_Order")
                        .HasColumnType("int");

                    b.Property<string>("Testimonial_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.Models.WhyChoosUs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("WhyUS_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhyUs_Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("WhyChoosUs");
                });

            modelBuilder.Entity("PlanningParadiseAdmin.ViewModel.AboutUsVM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About_Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Para1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Para2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Para3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_Qoute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("AboutUsVM");
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
                    b.HasOne("PlanningParadiseAdmin.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PlanningParadiseAdmin.Data.ApplicationUser", null)
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

                    b.HasOne("PlanningParadiseAdmin.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PlanningParadiseAdmin.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
