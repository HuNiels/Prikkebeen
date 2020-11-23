﻿// <auto-generated />
using System;
using Acupunctuur.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Acupunctuur.Migrations
{
    [DbContext(typeof(AcupunctuurContext))]
    [Migration("20200730092331_PrivacyInformation")]
    partial class PrivacyInformation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acupunctuur.Models.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RawHtml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("Acupunctuur.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("FileData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Acupunctuur.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Acupunctuur.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Cancelled")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TimeslotId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TimeslotId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Acupunctuur.Models.Timeslot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DoubleSlot")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Timeslots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 9, 15, 0, 0),
                            StartTime = new TimeSpan(0, 8, 30, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 10, 15, 0, 0),
                            StartTime = new TimeSpan(0, 9, 30, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            DoubleSlot = true,
                            EndTime = new TimeSpan(0, 10, 0, 0, 0),
                            StartTime = new TimeSpan(0, 8, 30, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 11, 30, 0, 0),
                            StartTime = new TimeSpan(0, 10, 45, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 12, 30, 0, 0),
                            StartTime = new TimeSpan(0, 11, 45, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            DoubleSlot = true,
                            EndTime = new TimeSpan(0, 12, 15, 0, 0),
                            StartTime = new TimeSpan(0, 10, 45, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 14, 15, 0, 0),
                            StartTime = new TimeSpan(0, 13, 30, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 15, 15, 0, 0),
                            StartTime = new TimeSpan(0, 14, 30, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 16, 15, 0, 0),
                            StartTime = new TimeSpan(0, 15, 30, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            DoubleSlot = true,
                            EndTime = new TimeSpan(0, 16, 0, 0, 0),
                            StartTime = new TimeSpan(0, 14, 30, 0, 0)
                        },
                        new
                        {
                            Id = 11,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 17, 15, 0, 0),
                            StartTime = new TimeSpan(0, 16, 30, 0, 0)
                        },
                        new
                        {
                            Id = 12,
                            DoubleSlot = false,
                            EndTime = new TimeSpan(0, 19, 45, 0, 0),
                            StartTime = new TimeSpan(0, 19, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("Acupunctuur.Models.TimeslotLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseId")
                        .HasColumnType("int");

                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseId");

                    b.HasIndex("LinkId");

                    b.ToTable("TimeslotLinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseId = 1,
                            LinkId = 3
                        },
                        new
                        {
                            Id = 2,
                            BaseId = 2,
                            LinkId = 3
                        },
                        new
                        {
                            Id = 3,
                            BaseId = 3,
                            LinkId = 1
                        },
                        new
                        {
                            Id = 4,
                            BaseId = 3,
                            LinkId = 2
                        },
                        new
                        {
                            Id = 5,
                            BaseId = 4,
                            LinkId = 6
                        },
                        new
                        {
                            Id = 6,
                            BaseId = 5,
                            LinkId = 6
                        },
                        new
                        {
                            Id = 7,
                            BaseId = 6,
                            LinkId = 4
                        },
                        new
                        {
                            Id = 8,
                            BaseId = 6,
                            LinkId = 5
                        },
                        new
                        {
                            Id = 9,
                            BaseId = 8,
                            LinkId = 10
                        },
                        new
                        {
                            Id = 10,
                            BaseId = 9,
                            LinkId = 10
                        },
                        new
                        {
                            Id = 11,
                            BaseId = 10,
                            LinkId = 8
                        },
                        new
                        {
                            Id = 12,
                            BaseId = 10,
                            LinkId = 9
                        });
                });

            modelBuilder.Entity("Acupunctuur.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NewUser")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("UserPrivacyInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserPrivacyInfoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Acupunctuur.Models.UserPrivacyInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrivacyInfo");
                });

            modelBuilder.Entity("Acupunctuur.Models.Page", b =>
                {
                    b.HasOne("Acupunctuur.Models.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("Acupunctuur.Models.Reservation", b =>
                {
                    b.HasOne("Acupunctuur.Models.Timeslot", "Timeslot")
                        .WithMany()
                        .HasForeignKey("TimeslotId");

                    b.HasOne("Acupunctuur.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Acupunctuur.Models.TimeslotLink", b =>
                {
                    b.HasOne("Acupunctuur.Models.Timeslot", "Base")
                        .WithMany("TimeslotBases")
                        .HasForeignKey("BaseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Acupunctuur.Models.Timeslot", "Link")
                        .WithMany("TimeslotLinks")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Acupunctuur.Models.User", b =>
                {
                    b.HasOne("Acupunctuur.Models.UserPrivacyInfo", "UserPrivacyInfo")
                        .WithMany()
                        .HasForeignKey("UserPrivacyInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
