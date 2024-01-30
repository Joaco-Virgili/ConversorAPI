﻿// <auto-generated />
using System;
using ConversorAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConversorAPI.Migrations
{
    [DbContext(typeof(ConversorDbContext))]
    [Migration("20240125180142_Agregado del resultado de conversion")]
    partial class Agregadodelresultadodeconversion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConversorAPI.Entites.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Currencys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dolar Estadounidense",
                            State = 0,
                            Symbol = "U$D",
                            Value = 1.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Euro",
                            State = 0,
                            Symbol = "€",
                            Value = 1.0900000000000001
                        },
                        new
                        {
                            Id = 3,
                            Name = "Peso Argentino",
                            State = 0,
                            Symbol = "$",
                            Value = 0.00020000000000000001
                        });
                });

            modelBuilder.Entity("ConversorAPI.Entites.CurrencyConversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromCurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("Result")
                        .HasColumnType("float");

                    b.Property<int>("ToCurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromCurrencyId");

                    b.HasIndex("ToCurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("CurrencyConversions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100.0,
                            Date = new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            FromCurrencyId = 2,
                            Result = 109.0,
                            ToCurrencyId = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("ConversorAPI.Entites.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountOfConversion")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountOfConversion = 10,
                            Name = "Free",
                            Price = 0,
                            State = 0
                        },
                        new
                        {
                            Id = 2,
                            AmountOfConversion = 100,
                            Name = "Premium",
                            Price = 10,
                            State = 0
                        },
                        new
                        {
                            Id = 3,
                            AmountOfConversion = -1,
                            Name = "Full",
                            Price = 25,
                            State = 0
                        });
                });

            modelBuilder.Entity("ConversorAPI.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "joaquinvirgili1@gmail.com",
                            LastName = "admin",
                            Name = "admin",
                            Password = "password",
                            Role = 0,
                            State = 0,
                            SubscriptionId = 3
                        },
                        new
                        {
                            Id = 2,
                            Email = "userexample@gmail.com",
                            LastName = "user",
                            Name = "user",
                            Password = "password",
                            Role = 1,
                            State = 0,
                            SubscriptionId = 1
                        });
                });

            modelBuilder.Entity("ConversorAPI.Entites.CurrencyConversion", b =>
                {
                    b.HasOne("ConversorAPI.Entites.Currency", "FromCurrency")
                        .WithMany()
                        .HasForeignKey("FromCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConversorAPI.Entites.Currency", "ToCurrency")
                        .WithMany()
                        .HasForeignKey("ToCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConversorAPI.Entites.User", "User")
                        .WithMany("CurrencyConversion")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromCurrency");

                    b.Navigation("ToCurrency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConversorAPI.Entites.User", b =>
                {
                    b.HasOne("ConversorAPI.Entites.Subscription", "Subscription")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ConversorAPI.Entites.Subscription", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ConversorAPI.Entites.User", b =>
                {
                    b.Navigation("CurrencyConversion");
                });
#pragma warning restore 612, 618
        }
    }
}
