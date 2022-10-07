﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.Api.Infra.Data.Context;

#nullable disable

namespace UrlShortener.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221007011011_AddTableFeatureToggle")]
    partial class AddTableFeatureToggle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("UrlShortener.Api.Models.FeatureToggle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("FeatureToggle", (string)null);
                });

            modelBuilder.Entity("UrlShortener.Api.Models.Url.UrlModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<string>("BaseUrl")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<string>("OriginalUrl")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Url", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
