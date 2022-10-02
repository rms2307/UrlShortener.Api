﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.Api.Infra.Data.Context;

#nullable disable

namespace UrlShortener.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

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
