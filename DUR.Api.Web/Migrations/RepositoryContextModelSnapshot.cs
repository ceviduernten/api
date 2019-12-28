﻿// <auto-generated />
using System;
using DUR.Api.Repo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DUR.Api.Web.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DUR.Api.Entities.Appointment", b =>
                {
                    b.Property<Guid>("IdAppointment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Infos")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Time")
                        .HasColumnType("text");

                    b.HasKey("IdAppointment");

                    b.HasIndex("GroupId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("DUR.Api.Entities.Contact", b =>
                {
                    b.Property<Guid>("IdContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Vulgo")
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("IdContact");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DUR.Api.Entities.Group", b =>
                {
                    b.Property<Guid>("IdGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Leaders")
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("IdGroup");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("DUR.Api.Entities.Appointment", b =>
                {
                    b.HasOne("DUR.Api.Entities.Group", "Group")
                        .WithMany("Appointments")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
