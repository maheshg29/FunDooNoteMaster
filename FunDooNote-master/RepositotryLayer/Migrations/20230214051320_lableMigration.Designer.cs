﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositotryLayer.contest;

namespace RepositotryLayer.Migrations
{
    [DbContext(typeof(fundocontext))]
    [Migration("20230214051320_lableMigration")]
    partial class lableMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepositotryLayer.entity.CollabEntity", b =>
                {
                    b.Property<long>("CollabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollabEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NoteId")
                        .HasColumnType("bigint");

                    b.HasKey("CollabId");

                    b.HasIndex("NoteId");

                    b.ToTable("CollabTable");
                });

            modelBuilder.Entity("RepositotryLayer.entity.LableEntity", b =>
                {
                    b.Property<long>("LableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LableId");

                    b.HasIndex("UserId");

                    b.ToTable("LableTable");
                });

            modelBuilder.Entity("RepositotryLayer.entity.NoteEntity", b =>
                {
                    b.Property<long>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archive")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Reminder")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Trash")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("NoteTable");
                });

            modelBuilder.Entity("RepositotryLayer.entity.NoteLableEntity", b =>
                {
                    b.Property<long>("NoteLableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LableId")
                        .HasColumnType("bigint");

                    b.Property<long>("NoteId")
                        .HasColumnType("bigint");

                    b.HasKey("NoteLableId");

                    b.HasIndex("LableId");

                    b.HasIndex("NoteId");

                    b.ToTable("NoteLableTable");
                });

            modelBuilder.Entity("RepositotryLayer.entity.userentity", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("usertable");
                });

            modelBuilder.Entity("RepositotryLayer.entity.CollabEntity", b =>
                {
                    b.HasOne("RepositotryLayer.entity.NoteEntity", "note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositotryLayer.entity.LableEntity", b =>
                {
                    b.HasOne("RepositotryLayer.entity.userentity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositotryLayer.entity.NoteEntity", b =>
                {
                    b.HasOne("RepositotryLayer.entity.userentity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositotryLayer.entity.NoteLableEntity", b =>
                {
                    b.HasOne("RepositotryLayer.entity.LableEntity", "lable")
                        .WithMany()
                        .HasForeignKey("LableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositotryLayer.entity.NoteEntity", "note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
