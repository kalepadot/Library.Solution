using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : DbContext
  {
    public virtual DbSet<Book> Books { get; set; }
    // public DbSet<Patron> Patrons { get; set; }
    // public DbSet<Checkout> Checkouts { get; set; }
    // public DbSet<Copy> Copies { get; set; }
    public DbSet<Author> Authors { get; set; }

    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}