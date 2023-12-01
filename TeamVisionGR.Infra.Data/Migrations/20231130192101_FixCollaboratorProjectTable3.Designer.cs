﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeamVisionGR.Infra.Data.Context;

#nullable disable

namespace TeamVisionGR.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231130192101_FixCollaboratorProjectTable3")]
    partial class FixCollaboratorProjectTable3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TeamVisionGR.Domain.Entities.Collaborator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Collaborator");
                });

            modelBuilder.Entity("TeamVisionGR.Domain.Entities.CollaboratorProject", b =>
                {
                    b.Property<Guid>("CollaboratorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CollaboratorId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("CollaboratorProject");
                });

            modelBuilder.Entity("TeamVisionGR.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("TeamVisionGR.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(62)
                        .HasColumnType("character varying(62)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TeamVisionGR.Domain.Entities.UserActivation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Activated")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ActivationMoment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Expired")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("SendingMoment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserActivation");
                });

            modelBuilder.Entity("TeamVisionGR.Domain.Entities.CollaboratorProject", b =>
                {
                    b.HasOne("TeamVisionGR.Domain.Entities.Collaborator", null)
                        .WithMany()
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamVisionGR.Domain.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamVisionGR.Domain.Entities.UserActivation", b =>
                {
                    b.HasOne("TeamVisionGR.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
