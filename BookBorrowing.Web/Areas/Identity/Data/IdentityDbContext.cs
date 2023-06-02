using BookBorrowing.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBorrowing.Web.Areas.Identity.Data;

public class IdentityDbContext : IdentityDbContext<Library>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new LibraryEntityConfiguration());
    }
}

public class LibraryEntityConfiguration : IEntityTypeConfiguration<Library>
{
    void IEntityTypeConfiguration<Library>.Configure(EntityTypeBuilder<Library> builder)
    {
        builder.Property(b  => b.Name).HasMaxLength(255);
    }
}