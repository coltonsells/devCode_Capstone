﻿// <auto-generated />
using System;
using Capstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capstone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181120165548_added feature bools to company")]
    partial class addedfeatureboolstocompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Capstone.Models.About", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<int>("ContainerAmount");

                    b.Property<string>("ContainerType");

                    b.Property<bool>("Maps");

                    b.Property<string>("NavTag");

                    b.Property<bool>("Twitter");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("AboutPages");
                });

            modelBuilder.Entity("Capstone.Models.AboutContainer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutId");

                    b.Property<string>("Align");

                    b.Property<string>("BgColor");

                    b.Property<string>("Color");

                    b.Property<int>("DivSection");

                    b.Property<string>("Font");

                    b.Property<string>("FontSize");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("AboutId");

                    b.ToTable("AboutContainers");
                });

            modelBuilder.Entity("Capstone.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("About");

                    b.Property<bool>("AboutSetupComplete");

                    b.Property<string>("City");

                    b.Property<bool>("Contact");

                    b.Property<bool>("ContactChoice");

                    b.Property<bool>("ContactSetupComplete");

                    b.Property<string>("CreatorId");

                    b.Property<bool>("HomeSetupComplete");

                    b.Property<string>("Lat");

                    b.Property<string>("Long");

                    b.Property<bool>("MapChoice");

                    b.Property<string>("Name");

                    b.Property<bool>("ScheduleChoice");

                    b.Property<bool>("SetupComplete");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("Theme");

                    b.Property<string>("Twitter");

                    b.Property<bool>("TwitterChoice");

                    b.Property<string>("Type");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Capstone.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<int>("ContainerAmount");

                    b.Property<string>("ContainerType");

                    b.Property<bool>("Maps");

                    b.Property<string>("NavTag");

                    b.Property<bool>("Twitter");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("ContactPages");
                });

            modelBuilder.Entity("Capstone.Models.ContactContainer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Align");

                    b.Property<string>("BgColor");

                    b.Property<string>("Color");

                    b.Property<string>("ContactId");

                    b.Property<int>("DivSection");

                    b.Property<string>("Font");

                    b.Property<string>("FontSize");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactContainers");
                });

            modelBuilder.Entity("Capstone.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Capstone.Models.Home", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<bool>("Maps");

                    b.Property<string>("NavTag");

                    b.Property<string>("Paragraph1");

                    b.Property<bool>("Paragraph1Check");

                    b.Property<string>("Paragraph1Type");

                    b.Property<string>("Paragraph2");

                    b.Property<bool>("Paragraph2Check");

                    b.Property<string>("Paragraph2Type");

                    b.Property<string>("Paragraph3");

                    b.Property<bool>("Paragraph3Check");

                    b.Property<string>("Paragraph3Type");

                    b.Property<bool>("Twitter");

                    b.HasKey("Id");

                    b.ToTable("HomePages");
                });

            modelBuilder.Entity("Capstone.Models.HomeContainer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Align");

                    b.Property<string>("BgColor");

                    b.Property<string>("Color");

                    b.Property<int>("DivSection");

                    b.Property<string>("Font");

                    b.Property<string>("FontSize");

                    b.Property<string>("HomeId");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("HomeContainers");
                });

            modelBuilder.Entity("Capstone.Models.HomeContentImages", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HomeId");

                    b.Property<byte[]>("Image");

                    b.HasKey("Id");

                    b.ToTable("HomeContentImages");
                });

            modelBuilder.Entity("Capstone.Models.HomeJumbo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("Text");

                    b.Property<string>("TextAlign");

                    b.Property<string>("TextColor");

                    b.Property<string>("TextFont");

                    b.Property<string>("TextSize");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("HomeJumbos");
                });

            modelBuilder.Entity("Capstone.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ImageByte");

                    b.Property<string>("ImagePath");

                    b.Property<string>("companyId");

                    b.HasKey("Id");

                    b.HasIndex("companyId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Capstone.Models.SpecialFeatures", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<bool>("Maps");

                    b.Property<bool>("Schedule");

                    b.Property<bool>("Twitter");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("SpecialFeatures");
                });

            modelBuilder.Entity("Capstone.Models.StandardFeatures", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("About");

                    b.Property<string>("CompanyId");

                    b.Property<bool>("Contact");

                    b.Property<bool>("Home");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("StandardFeatures");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Capstone.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("name");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Capstone.Models.About", b =>
                {
                    b.HasOne("Capstone.Models.Company", "company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Capstone.Models.AboutContainer", b =>
                {
                    b.HasOne("Capstone.Models.About", "about")
                        .WithMany()
                        .HasForeignKey("AboutId");
                });

            modelBuilder.Entity("Capstone.Models.Contact", b =>
                {
                    b.HasOne("Capstone.Models.Company", "company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Capstone.Models.ContactContainer", b =>
                {
                    b.HasOne("Capstone.Models.Contact", "contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("Capstone.Models.Customer", b =>
                {
                    b.HasOne("Capstone.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Capstone.Models.HomeContainer", b =>
                {
                    b.HasOne("Capstone.Models.Home", "home")
                        .WithMany()
                        .HasForeignKey("HomeId");
                });

            modelBuilder.Entity("Capstone.Models.HomeJumbo", b =>
                {
                    b.HasOne("Capstone.Models.Company", "company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Capstone.Models.Image", b =>
                {
                    b.HasOne("Capstone.Models.Company", "company")
                        .WithMany()
                        .HasForeignKey("companyId");
                });

            modelBuilder.Entity("Capstone.Models.SpecialFeatures", b =>
                {
                    b.HasOne("Capstone.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Capstone.Models.StandardFeatures", b =>
                {
                    b.HasOne("Capstone.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
