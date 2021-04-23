﻿// <auto-generated />
using System;
using DUR.Api.Repo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DUR.Api.Web.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210422185131_AddedAppointmentResponses")]
    partial class AddedAppointmentResponses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DUR.Api.Entities.Admin.User", b =>
                {
                    b.Property<Guid>("IdUser")
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

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("LoginName")
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Vulgo")
                        .HasColumnType("text");

                    b.HasKey("IdUser");

                    b.ToTable("User");
                });

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

            modelBuilder.Entity("DUR.Api.Entities.AppointmentResponse", b =>
                {
                    b.Property<Guid>("IdAppointmentResponse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("IdAppointmentResponse");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentResponse");
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

            modelBuilder.Entity("DUR.Api.Entities.Easter.HuntCity", b =>
                {
                    b.Property<Guid>("IdHuntCity")
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

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("StartLocationLat")
                        .HasColumnType("text");

                    b.Property<string>("StartLocationLong")
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.Property<int>("ZoomLevel")
                        .HasColumnType("integer");

                    b.HasKey("IdHuntCity");

                    b.ToTable("HuntCity");
                });

            modelBuilder.Entity("DUR.Api.Entities.Easter.HuntLocation", b =>
                {
                    b.Property<Guid>("IdHuntLocation")
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

                    b.Property<Guid>("HuntCityIdHuntCity")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFound")
                        .HasColumnType("boolean");

                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("IdHuntLocation");

                    b.HasIndex("HuntCityIdHuntCity");

                    b.ToTable("HuntLocation");
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

                    b.Property<string>("MailLeaders")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NumberNotification")
                        .HasColumnType("text");

                    b.HasKey("IdGroup");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("DUR.Api.Entities.Stuff.Box", b =>
                {
                    b.Property<Guid>("IdBox")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BoxType")
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .HasColumnType("text");

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

                    b.Property<bool>("InUse")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LocationIdStorageLocation")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<bool>("Stackable")
                        .HasColumnType("boolean");

                    b.Property<bool>("WithCover")
                        .HasColumnType("boolean");

                    b.HasKey("IdBox");

                    b.HasIndex("LocationIdStorageLocation");

                    b.ToTable("Box");
                });

            modelBuilder.Entity("DUR.Api.Entities.Stuff.Item", b =>
                {
                    b.Property<Guid>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BoxIdBox")
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

                    b.Property<Guid?>("LocationIdStorageLocation")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityType")
                        .HasColumnType("integer");

                    b.HasKey("IdItem");

                    b.HasIndex("BoxIdBox");

                    b.HasIndex("LocationIdStorageLocation");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("DUR.Api.Entities.Stuff.StorageLocation", b =>
                {
                    b.Property<Guid>("IdStorageLocation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

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

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.Property<int>("Zip")
                        .HasColumnType("integer");

                    b.HasKey("IdStorageLocation");

                    b.ToTable("StorageLocation");
                });

            modelBuilder.Entity("DUR.Api.Entities.Appointment", b =>
                {
                    b.HasOne("DUR.Api.Entities.Group", "Group")
                        .WithMany("Appointments")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("DUR.Api.Entities.AppointmentResponse", b =>
                {
                    b.HasOne("DUR.Api.Entities.Appointment", "Appointment")
                        .WithMany("Responses")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("DUR.Api.Entities.Easter.HuntLocation", b =>
                {
                    b.HasOne("DUR.Api.Entities.Easter.HuntCity", "HuntCity")
                        .WithMany("Locations")
                        .HasForeignKey("HuntCityIdHuntCity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HuntCity");
                });

            modelBuilder.Entity("DUR.Api.Entities.Stuff.Box", b =>
                {
                    b.HasOne("DUR.Api.Entities.Stuff.StorageLocation", "Location")
                        .WithMany("Boxes")
                        .HasForeignKey("LocationIdStorageLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DUR.Api.Entities.Stuff.Item", b =>
                {
                    b.HasOne("DUR.Api.Entities.Stuff.Box", "Box")
                        .WithMany("Items")
                        .HasForeignKey("BoxIdBox");

                    b.HasOne("DUR.Api.Entities.Stuff.StorageLocation", "Location")
                        .WithMany("Items")
                        .HasForeignKey("LocationIdStorageLocation")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Box");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DUR.Api.Entities.Appointment", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("DUR.Api.Entities.Easter.HuntCity", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("DUR.Api.Entities.Group", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("DUR.Api.Entities.Stuff.Box", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("DUR.Api.Entities.Stuff.StorageLocation", b =>
                {
                    b.Navigation("Boxes");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
