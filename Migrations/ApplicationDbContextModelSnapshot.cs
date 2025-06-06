﻿// <auto-generated />
using System;
using JobMatch.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobMatch.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("JobMatch.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Employers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Tech Street, Techland",
                            Description = "Tech Solutions Inc. is a leading provider of IT consulting services, specializing in software development, cloud computing, and cybersecurity solutions.",
                            Email = "info@techsolutions.com",
                            Name = "Tech Solutions Inc.",
                            Phone = "123-456-7890",
                            UserId = "b29b9de1-8b79-4a45-8a24-8d8e13345158"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Logistics Avenue, Cityville",
                            Description = "Global Logistics Group is a multinational logistics company offering end-to-end supply chain solutions, including transportation, warehousing, and freight forwarding services.",
                            Email = "contact@globallogistics.com",
                            Name = "Global Logistics Group",
                            Phone = "987-654-3210",
                            UserId = "fe28485f-d975-4a30-82c9-3fdfa0395cec"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Education Street, Learning City",
                            Description = "Bright Minds Academy is an innovative educational institution committed to providing high-quality learning experiences for students of all ages. Our curriculum emphasizes creativity, critical thinking, and personal growth.",
                            Email = "info@brightminds.edu",
                            Name = "Bright Minds Academy",
                            Phone = "111-222-3333",
                            UserId = "27e828d1-d603-4695-ba26-a15ca6dd8d85"
                        },
                        new
                        {
                            Id = 4,
                            Address = "101 Medical Drive, Healthtown",
                            Description = "HealthCare Innovations LLC is a healthcare technology company focused on developing innovative solutions to improve patient care, enhance clinical workflows, and optimize healthcare delivery.",
                            Email = "info@healthcareinnovations.com",
                            Name = "HealthCare Innovations LLC",
                            Phone = "444-555-6666",
                            UserId = "a7c1cade-8875-4285-86a7-d3a160431965"
                        },
                        new
                        {
                            Id = 5,
                            Address = "222 Design Avenue, Creativityville",
                            Description = "Creative Designs Agency is a full-service creative agency specializing in graphic design, branding, web development, and digital marketing services. We help businesses build strong visual identities and engaging online presences.",
                            Email = "contact@creativedesigns.com",
                            Name = "Creative Designs Agency",
                            Phone = "777-888-9999",
                            UserId = "315883da-d6f5-44c7-8e63-99660017e836"
                        },
                        new
                        {
                            Id = 6,
                            Address = "333 Renewable Road, Eco City",
                            Description = "Green Energy Solutions Ltd. is a renewable energy company dedicated to promoting sustainability and environmental responsibility. We offer a range of clean energy solutions, including solar power, wind energy, and energy-efficient technologies.",
                            Email = "info@greenenergy.com",
                            Name = "Green Energy Solutions Ltd.",
                            Phone = "333-444-5555",
                            UserId = "fc990428-db81-431a-87cb-de59e251722b"
                        },
                        new
                        {
                            Id = 7,
                            Address = "777 Finance Street, Moneytown",
                            Description = "Financial Strategies Group is a financial planning firm specializing in retirement planning, investment management, and wealth preservation strategies. Our team of experienced advisors helps clients achieve their financial goals and secure their financial future.",
                            Email = "contact@financialstrategies.com",
                            Name = "Financial Strategies Group",
                            Phone = "666-777-8888",
                            UserId = "f6606a8b-0544-46a6-b94c-e4a3ab735206"
                        },
                        new
                        {
                            Id = 8,
                            Address = "888 Hospitality Boulevard, Welcoming City",
                            Description = "Hospitality Haven Inc. is a hospitality management company operating a portfolio of hotels, resorts, and restaurants worldwide. We are committed to providing exceptional guest experiences and creating memorable moments for our guests.",
                            Email = "info@hospitalityhaven.com",
                            Name = "Hospitality Haven Inc.",
                            Phone = "999-000-1111",
                            UserId = "7c33510b-08e5-4510-921f-8463d4dd138d"
                        },
                        new
                        {
                            Id = 9,
                            Address = "555 Engineering Avenue, Innovation City",
                            Description = "Innovative Engineering Solutions is a leading engineering consultancy firm offering a wide range of engineering services, including structural design, civil engineering, and project management. We deliver innovative solutions to complex engineering challenges.",
                            Email = "info@innovativeengg.com",
                            Name = "Innovative Engineering Solutions",
                            Phone = "222-333-4444",
                            UserId = "1d4342c2-3e45-4cf4-89aa-2aa63f67990b"
                        },
                        new
                        {
                            Id = 10,
                            Address = "999 HR Street, Talent City",
                            Description = "PeopleFirst HR Consulting is a human resources consulting firm specializing in talent acquisition, employee engagement, and organizational development. We partner with businesses to attract, develop, and retain top talent.",
                            Email = "contact@peoplefirsthr.com",
                            Name = "PeopleFirst HR Consulting",
                            Phone = "000-111-2222",
                            UserId = "f35c9366-6d00-482f-8836-47185ba16ef1"
                        });
                });

            modelBuilder.Entity("JobMatch.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Salary")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobMatch.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppliedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("JobSeekerId")
                        .HasColumnType("int");

                    b.Property<string>("Resume")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("JobSeekerId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("JobMatch.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Jobs related to software development, including roles such as software engineer, web developer, and mobile app developer.",
                            Name = "Software Development",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Jobs related to data science and analytics, involving tasks such as data analysis, machine learning, and statistical modeling.",
                            Name = "Data Science",
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Jobs related to marketing and advertising, encompassing roles like digital marketer, social media manager, and marketing strategist.",
                            Name = "Marketing",
                            Status = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Jobs in the finance industry, including positions such as financial analyst, accountant, and investment banker.",
                            Name = "Finance",
                            Status = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Jobs in the healthcare sector, covering roles such as nurse, doctor, pharmacist, and medical researcher.",
                            Name = "Healthcare",
                            Status = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Jobs in the education field, including positions such as teacher, professor, academic advisor, and curriculum developer.",
                            Name = "Education",
                            Status = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "Jobs in the hospitality industry, involving roles such as hotel manager, chef, event planner, and travel agent.",
                            Name = "Hospitality",
                            Status = 1
                        },
                        new
                        {
                            Id = 8,
                            Description = "Jobs in various engineering disciplines, including mechanical engineering, civil engineering, electrical engineering, and aerospace engineering.",
                            Name = "Engineering",
                            Status = 1
                        },
                        new
                        {
                            Id = 9,
                            Description = "Jobs in human resources management, covering roles such as HR manager, recruiter, training coordinator, and benefits specialist.",
                            Name = "Human Resources",
                            Status = 1
                        },
                        new
                        {
                            Id = 10,
                            Description = "Jobs in design fields such as graphic design, UX/UI design, interior design, and fashion design.",
                            Name = "Design",
                            Status = 1
                        });
                });

            modelBuilder.Entity("JobMatch.JobSeeker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Education")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Resume")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("JobSeekers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Education = "High School",
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            Phone = "123-456-7890",
                            UserId = "ce519b82-33ba-41ca-9fe4-db858e78dbfb"
                        },
                        new
                        {
                            Id = 2,
                            Education = "College",
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            Phone = "987-654-3210",
                            UserId = "9ea11d53-f1a9-4b4e-aadc-04151abea960"
                        },
                        new
                        {
                            Id = 3,
                            Education = "University",
                            Email = "michael.johnson@example.com",
                            Name = "Michael Johnson",
                            Phone = "111-222-3333",
                            UserId = "1c43829d-02e8-49c4-b78a-42f38eb87a2e"
                        },
                        new
                        {
                            Id = 4,
                            Education = "Master",
                            Email = "emily.brown@example.com",
                            Name = "Emily Brown",
                            Phone = "444-555-6666",
                            UserId = "12bca86d-e01f-4920-be31-36e9acf29729"
                        },
                        new
                        {
                            Id = 5,
                            Education = "PhD",
                            Email = "daniel.wilson@example.com",
                            Name = "Daniel Wilson",
                            Phone = "777-888-9999",
                            UserId = "f33c0fd8-1cb8-4cc3-a39e-2140de9daed0"
                        },
                        new
                        {
                            Id = 6,
                            Education = "Other",
                            Email = "sarah.taylor@example.com",
                            Name = "Sarah Taylor",
                            Phone = "333-444-5555",
                            UserId = "fc7bbd1d-f85a-4c6f-a839-9093a568c77c"
                        },
                        new
                        {
                            Id = 7,
                            Education = "High School",
                            Email = "matthew.anderson@example.com",
                            Name = "Matthew Anderson",
                            Phone = "666-777-8888",
                            UserId = "b4dce528-4190-44cb-b8bd-60d183c9fc22"
                        },
                        new
                        {
                            Id = 8,
                            Education = "College",
                            Email = "olivia.martinez@example.com",
                            Name = "Olivia Martinez",
                            Phone = "999-000-1111",
                            UserId = "b6897cb1-1a04-4e10-bf51-63022181ce9b"
                        },
                        new
                        {
                            Id = 9,
                            Education = "University",
                            Email = "james.wilson@example.com",
                            Name = "James Wilson",
                            Phone = "222-333-4444",
                            UserId = "23bbf3df-a7ec-4711-80b0-6594da94c8b3"
                        },
                        new
                        {
                            Id = 10,
                            Education = "Master",
                            Email = "sophia.johnson@example.com",
                            Name = "Sophia Johnson",
                            Phone = "000-111-2222",
                            UserId = "23e09f47-3939-4401-8a29-40605cf328e1"
                        });
                });

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

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("JobMatch.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("password_reset_token")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("JobMatch.Employer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("JobMatch.Job", b =>
                {
                    b.HasOne("JobMatch.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobMatch.JobCategory", "JobCategory")
                        .WithMany()
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("JobMatch.JobApplication", b =>
                {
                    b.HasOne("JobMatch.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobMatch.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("JobSeeker");
                });

            modelBuilder.Entity("JobMatch.JobSeeker", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
