﻿// <auto-generated />
using System;
using CA.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CA.Persistance.Migrations.InitialSetup
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CA.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "1001",
                            Name = "Martin Fowler"
                        },
                        new
                        {
                            Id = 2,
                            Code = "1002",
                            Name = "Uncle Bob"
                        },
                        new
                        {
                            Id = 3,
                            Code = "1003",
                            Name = "Kent Beck"
                        });
                });

            modelBuilder.Entity("CA.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Eric Evans"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Greg Young"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Udi Dahan"
                        });
                });

            modelBuilder.Entity("CA.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Spaghetti",
                            Price = 5m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lasagna",
                            Price = 10m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ravioli",
                            Price = 15m
                        });
                });

            modelBuilder.Entity("CA.Domain.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Date = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeId = 1,
                            ProductId = 1,
                            Quantity = 1,
                            TotalPrice = 5m,
                            UnitPrice = 5m
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Date = new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeId = 2,
                            ProductId = 2,
                            Quantity = 2,
                            TotalPrice = 20m,
                            UnitPrice = 10m
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            Date = new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeId = 3,
                            ProductId = 3,
                            Quantity = 3,
                            TotalPrice = 45m,
                            UnitPrice = 15m
                        });
                });

            modelBuilder.Entity("CA.Domain.Entities.Sale", b =>
                {
                    b.HasOne("CA.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CA.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CA.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
