﻿// <auto-generated />
using System;
using IRFestival.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IRFestival.Api.Migrations
{
    [DbContext(typeof(FestivalDbContext))]
    [Migration("20221013080644_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IRFestival.Api.Domain.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FestivalId = 1,
                            ImagePath = "dianaross.jpg",
                            Name = "Diana Ross",
                            Website = "http://www.dianaross.co.uk/indexb.html"
                        },
                        new
                        {
                            Id = 2,
                            FestivalId = 1,
                            ImagePath = "thecommodores.jpg",
                            Name = "The Commodores",
                            Website = "http://en.wikipedia.org/wiki/Commodores"
                        },
                        new
                        {
                            Id = 3,
                            FestivalId = 1,
                            ImagePath = "steviewonder.jpg",
                            Name = "Stevie Wonder",
                            Website = "http://www.steviewonder.net/"
                        },
                        new
                        {
                            Id = 4,
                            FestivalId = 1,
                            ImagePath = "lionelrichie.jpg",
                            Name = "Lionel Richie",
                            Website = "http://lionelrichie.com/"
                        },
                        new
                        {
                            Id = 5,
                            FestivalId = 1,
                            ImagePath = "marvingaye.jpg",
                            Name = "Lucky luckyyyy",
                            Website = "http://www.marvingayepage.net/"
                        });
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Festival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Festivals");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId")
                        .IsUnique();

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FestivalId = 1
                        });
                });

            modelBuilder.Entity("IRFestival.Api.Domain.ScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("StageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("StageId");

                    b.ToTable("ScheduleItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 1, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 5,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 4,
                            Time = new DateTime(1972, 7, 1, 20, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 3,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 1, 22, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 2,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 2,
                            Time = new DateTime(1972, 7, 1, 22, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 1,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 2, 20, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 5,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 4,
                            Time = new DateTime(1972, 7, 2, 20, 45, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            ArtistId = 4,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 2, 22, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            ArtistId = 2,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 2,
                            Time = new DateTime(1972, 7, 2, 22, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("Stages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical",
                            FestivalId = 1,
                            Name = "Main Stage"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical",
                            FestivalId = 1,
                            Name = "Orange Room"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical",
                            FestivalId = 1,
                            Name = "StarDust"
                        },
                        new
                        {
                            Id = 4,
                            Description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical",
                            FestivalId = 1,
                            Name = "Blue Room"
                        });
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Artist", b =>
                {
                    b.HasOne("IRFestival.Api.Domain.Festival", "Festival")
                        .WithMany("Artists")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Schedule", b =>
                {
                    b.HasOne("IRFestival.Api.Domain.Festival", "Festival")
                        .WithOne("LineUp")
                        .HasForeignKey("IRFestival.Api.Domain.Schedule", "FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("IRFestival.Api.Domain.ScheduleItem", b =>
                {
                    b.HasOne("IRFestival.Api.Domain.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("IRFestival.Api.Domain.Schedule", "Schedule")
                        .WithMany("Items")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("IRFestival.Api.Domain.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId");

                    b.Navigation("Artist");

                    b.Navigation("Schedule");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Stage", b =>
                {
                    b.HasOne("IRFestival.Api.Domain.Festival", "Festival")
                        .WithMany("Stages")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Festival", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("LineUp")
                        .IsRequired();

                    b.Navigation("Stages");
                });

            modelBuilder.Entity("IRFestival.Api.Domain.Schedule", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
