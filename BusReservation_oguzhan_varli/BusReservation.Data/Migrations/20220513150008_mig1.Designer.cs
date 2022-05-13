﻿// <auto-generated />
using System;
using BusReservation.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusReservation.Data.Migrations
{
    [DbContext(typeof(BusResContext))]
    [Migration("20220513150008_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("BusReservation.Entity.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("BusReservation.Entity.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("RouteClock")
                        .HasColumnType("REAL");

                    b.Property<string>("RouteDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RouteFinish")
                        .HasColumnType("TEXT");

                    b.Property<string>("RouteFirstTransfer")
                        .HasColumnType("TEXT");

                    b.Property<string>("RouteFourthTransfer")
                        .HasColumnType("TEXT");

                    b.Property<double>("RoutePrice")
                        .HasColumnType("REAL");

                    b.Property<string>("RouteSecondTransfer")
                        .HasColumnType("TEXT");

                    b.Property<string>("RouteStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("RouteThirdTransfer")
                        .HasColumnType("TEXT");

                    b.HasKey("RouteId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("BusReservation.Entity.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RouteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TicketDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketFromWhere")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketName")
                        .HasColumnType("TEXT");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("TicketSeatNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TicketSurname")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketToWhere")
                        .HasColumnType("TEXT");

                    b.HasKey("TicketId");

                    b.HasIndex("CityId");

                    b.HasIndex("RouteId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BusReservation.Entity.Ticket", b =>
                {
                    b.HasOne("BusReservation.Entity.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("BusReservation.Entity.Route", "Route")
                        .WithMany("Ticket")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("BusReservation.Entity.Route", b =>
                {
                    b.Navigation("Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}
