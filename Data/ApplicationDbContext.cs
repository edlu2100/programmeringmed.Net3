using Microsoft.EntityFrameworkCore;
using programmeringmed.Net3.Models;
namespace programmeringmed.Net3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<BookModel> Books { get; set; }
    public DbSet<AuthorModel> Authors { get; set; }
    public DbSet<PersonModel> Persons { get; set; }

    public DbSet<BorrowModel> Borrows { get; set; }


}