using Microsoft.EntityFrameworkCore.Design;
using BookBorrowing.DATA.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowing.Web
{
    public class BookBorrowingFactory : IDesignTimeDbContextFactory<BookBorrowingContext>
    {
        public BookBorrowingContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<BookBorrowingContext>()
                .UseSqlServer(config.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("BookBorrowing.Web"));

            return new BookBorrowingContext(builder.Options);
        }
    }
}
