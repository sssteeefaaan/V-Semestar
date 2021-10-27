﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Models;

namespace Server.Migrations
{
    [DbContext(typeof(KlubContext))]
    [Migration("20210105193514_V7")]
    partial class V7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Server.Models.Polica", b =>
                {
                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Oznaka");

                    b.Property<int>("VideoKlubID")
                        .HasColumnType("int")
                        .HasColumnName("Video Klub ID");

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Boja");

                    b.Property<int>("Curr")
                        .HasColumnType("int")
                        .HasColumnName("Curr");

                    b.Property<int>("Max")
                        .HasColumnType("int")
                        .HasColumnName("Max");

                    b.HasKey("Oznaka", "VideoKlubID");

                    b.HasIndex("VideoKlubID");

                    b.ToTable("Polica");
                });

            modelBuilder.Entity("Server.Models.VideoKlub", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("Video Klub");
                });

            modelBuilder.Entity("Server.Models.Polica", b =>
                {
                    b.HasOne("Server.Models.VideoKlub", "VideoKlub")
                        .WithMany("Police")
                        .HasForeignKey("VideoKlubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VideoKlub");
                });

            modelBuilder.Entity("Server.Models.VideoKlub", b =>
                {
                    b.Navigation("Police");
                });
#pragma warning restore 612, 618
        }
    }
}
