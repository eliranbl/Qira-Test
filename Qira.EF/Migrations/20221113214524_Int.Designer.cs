// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Qira.EF;

#nullable disable

namespace Qira.EF.Migrations
{
    [DbContext(typeof(QiraDbContext))]
    [Migration("20221113214524_Int")]
    partial class Int
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Qira.Domain.Invoices.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDataTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("ProcessingStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invoices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100.0,
                            CreatedDateTime = new DateTime(2022, 11, 13, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6411),
                            PaymentMethod = 1,
                            ProcessingStatus = 1
                        },
                        new
                        {
                            Id = 25,
                            Amount = 10.5,
                            CreatedDateTime = new DateTime(2022, 11, 13, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6419),
                            PaymentMethod = 2,
                            ProcessingStatus = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 25.899999999999999,
                            CreatedDateTime = new DateTime(2022, 11, 14, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6420),
                            PaymentMethod = 3,
                            ProcessingStatus = 1
                        },
                        new
                        {
                            Id = 14,
                            Amount = 50.049999999999997,
                            CreatedDateTime = new DateTime(2022, 11, 15, 23, 45, 24, 282, DateTimeKind.Utc).AddTicks(6428),
                            PaymentMethod = 1,
                            ProcessingStatus = 3
                        },
                        new
                        {
                            Id = 315,
                            Amount = 864.5,
                            CreatedDateTime = new DateTime(2022, 11, 8, 21, 45, 24, 282, DateTimeKind.Utc).AddTicks(6430),
                            PaymentMethod = 1,
                            ProcessingStatus = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
