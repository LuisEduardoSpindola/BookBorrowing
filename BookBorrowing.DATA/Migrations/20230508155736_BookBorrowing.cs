using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookBorrowing.DATA.Migrations
{
    /// <inheritdoc />
    public partial class BookBorrowing : Migration
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
                    bookName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    authorName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: false),
                    publisherName = table.Column<string>(type: "nchar(150)", fixedLength: true, maxLength: 150, nullable: true),
                    publishDate = table.Column<DateTime>(type: "date", nullable: false),
                    bookEdition = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    bookImg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.idBook);
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
                    table.PrimaryKey("PK_Client", x => x.idClient);
                });

            migrationBuilder.CreateTable(
                name: "Borrowing",
                columns: table => new
                {
                    idBorrowing = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBook = table.Column<int>(type: "int", nullable: false),
                    idClient = table.Column<int>(type: "int", nullable: false),
                    borrowingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    devolutionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    borrowingAdress = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing", x => x.idBorrowing);
                    table.ForeignKey(
                        name: "FK_Borrowing_Book",
                        column: x => x.idBook,
                        principalTable: "Book",
                        principalColumn: "idBook");
                    table.ForeignKey(
                        name: "FK_Borrowing_Client",
                        column: x => x.idClient,
                        principalTable: "Client",
                        principalColumn: "idClient");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_idBook",
                table: "Borrowing",
                column: "idBook");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_idClient",
                table: "Borrowing",
                column: "idClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrowing");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
