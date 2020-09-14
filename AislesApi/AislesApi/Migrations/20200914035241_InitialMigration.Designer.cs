﻿// <auto-generated />
using AislesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AislesAPI.Migrations
{
    [DbContext(typeof(AppDatabase))]
    [Migration("20200914035241_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AislesAPI.Models.Aisle", b =>
                {
                    b.Property<int>("AisleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AisleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AisleID");

                    b.ToTable("Aisles");
                });

            modelBuilder.Entity("AislesAPI.Models.Section", b =>
                {
                    b.Property<int>("SectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AisleID")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionID");

                    b.HasIndex("AisleID");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("AislesAPI.Models.Section", b =>
                {
                    b.HasOne("AislesAPI.Models.Aisle", null)
                        .WithMany("Sections")
                        .HasForeignKey("AisleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}