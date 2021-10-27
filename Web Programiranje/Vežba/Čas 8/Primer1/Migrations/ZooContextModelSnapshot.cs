﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Primer1.Models;

namespace Primer1.Migrations
{
    [DbContext(typeof(ZooContext))]
    partial class ZooContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Primer1.Models.Lokacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<int>("MaxKapacitet")
                        .HasColumnType("int")
                        .HasColumnName("MaxKapacitet");

                    b.Property<string>("Tip")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Tip");

                    b.Property<string>("Vrsta")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Vrsta");

                    b.Property<int?>("VrtID")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("X");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.HasKey("ID");

                    b.HasIndex("VrtID");

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("Primer1.Models.Vrt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<int>("M")
                        .HasColumnType("int")
                        .HasColumnName("M");

                    b.Property<int>("N")
                        .HasColumnType("int")
                        .HasColumnName("N");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("ZooVrt");
                });

            modelBuilder.Entity("Primer1.Models.Lokacija", b =>
                {
                    b.HasOne("Primer1.Models.Vrt", "Vrt")
                        .WithMany("Lokacije")
                        .HasForeignKey("VrtID");

                    b.Navigation("Vrt");
                });

            modelBuilder.Entity("Primer1.Models.Vrt", b =>
                {
                    b.Navigation("Lokacije");
                });
#pragma warning restore 612, 618
        }
    }
}
