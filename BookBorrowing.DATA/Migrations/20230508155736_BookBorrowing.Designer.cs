﻿// <auto-generated />
using System;
using BookBorrowing.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookBorrowing.DATA.Migrations
{
    [DbContext(typeof(BookBorrowingContext))]
    [Migration("20230508155736_BookBorrowing")]
    partial class BookBorrowing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookBorrowing.DATA.Models.Book", b =>
                {
                    b.Property<int>("IdBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idBook");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBook"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nchar(150)")
                        .HasColumnName("authorName")
                        .IsFixedLength();

                    b.Property<string>("BookEdition")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("bookEdition")
                        .IsFixedLength();

                    b.Property<string>("BookImg")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("bookImg");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .HasColumnName("bookName")
                        .IsFixedLength();

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("date")
                        .HasColumnName("publishDate");

                    b.Property<string>("PublisherName")
                        .HasMaxLength(150)
                        .HasColumnType("nchar(150)")
                        .HasColumnName("publisherName")
                        .IsFixedLength();

                    b.HasKey("IdBook");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookBorrowing.DATA.Models.Borrowing", b =>
                {
                    b.Property<int>("IdBorrowing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idBorrowing");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBorrowing"));

                    b.Property<string>("BorrowingAdress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .HasColumnName("borrowingAdress")
                        .IsFixedLength();

                    b.Property<DateTime>("BorrowingDate")
                        .HasColumnType("datetime")
                        .HasColumnName("borrowingDate");

                    b.Property<DateTime>("DevolutionDate")
                        .HasColumnType("datetime")
                        .HasColumnName("devolutionDate");

                    b.Property<int>("IdBook")
                        .HasColumnType("int")
                        .HasColumnName("idBook");

                    b.Property<int>("IdClient")
                        .HasColumnType("int")
                        .HasColumnName("idClient");

                    b.HasKey("IdBorrowing");

                    b.HasIndex("IdBook");

                    b.HasIndex("IdClient");

                    b.ToTable("Borrowing");
                });

            modelBuilder.Entity("BookBorrowing.DATA.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idClient");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .HasColumnName("adress")
                        .IsFixedLength();

                    b.Property<string>("CellNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nchar(14)")
                        .HasColumnName("cellNumber")
                        .IsFixedLength();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nchar(25)")
                        .HasColumnName("city")
                        .IsFixedLength();

                    b.Property<string>("ClientCpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nchar(14)")
                        .HasColumnName("clientCPF")
                        .IsFixedLength();

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nchar(150)")
                        .HasColumnName("clientName")
                        .IsFixedLength();

                    b.HasKey("IdClient");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BookBorrowing.DATA.Models.Borrowing", b =>
                {
                    b.HasOne("BookBorrowing.DATA.Models.Book", "IdBookNavigation")
                        .WithMany("Borrowing")
                        .HasForeignKey("IdBook")
                        .IsRequired()
                        .HasConstraintName("FK_Borrowing_Book");

                    b.HasOne("BookBorrowing.DATA.Models.Client", "IdClientNavigation")
                        .WithMany("Borrowing")
                        .HasForeignKey("IdClient")
                        .IsRequired()
                        .HasConstraintName("FK_Borrowing_Client");

                    b.Navigation("IdBookNavigation");

                    b.Navigation("IdClientNavigation");
                });

            modelBuilder.Entity("BookBorrowing.DATA.Models.Book", b =>
                {
                    b.Navigation("Borrowing");
                });

            modelBuilder.Entity("BookBorrowing.DATA.Models.Client", b =>
                {
                    b.Navigation("Borrowing");
                });
#pragma warning restore 612, 618
        }
    }
}
