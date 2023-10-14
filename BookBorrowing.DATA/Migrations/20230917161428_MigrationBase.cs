using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookBorrowing.DATA.Migrations
{
    /// <inheritdoc />
    public partial class MigrationBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    idBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    authorName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    publisherName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    publisherDate = table.Column<DateTime>(type: "date", nullable: true),
                    bookEdition = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: true),
                    bookImg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_1", x => x.idBook);
                });

            migrationBuilder.CreateTable(
                name: "Borrowing",
                columns: table => new
                {
                    idBorrowing = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBorrowingClient = table.Column<int>(type: "int", nullable: false),
                    idBorrowingBook = table.Column<int>(type: "int", nullable: false),
                    borrowingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    devolutionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    returned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing_1", x => x.idBorrowing);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    idClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: false),
                    clientCPF = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: false),
                    adress = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nchar(25)", fixedLength: true, maxLength: 25, nullable: false),
                    cellNumber = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_1", x => x.idClient);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Borrowing");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
