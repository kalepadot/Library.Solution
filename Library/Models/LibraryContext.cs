using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// namespace BasicAuthentication.Models 
namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<AuthorBook> AuthorBook { get; set; }
    public virtual DbSet<Copy> Copies { get; set; }
    public virtual DbSet<Patron> Patrons { get; set; }
    public virtual DbSet<CopyPatron> CopyPatrons { get; set; }
   

    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}