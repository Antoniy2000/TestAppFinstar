﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAppFinstar.Data.Contexts;

#nullable disable

namespace TestAppFinstar.Data.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20250322145150_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("TestAppFinstar.Models.Entities.SomeData", b =>
                {
                    b.Property<long>("Ordinal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Ordinal");

                    b.ToTable("SomeData");
                });
#pragma warning restore 612, 618
        }
    }
}
