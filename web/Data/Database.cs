using Microsoft.EntityFrameworkCore;

namespace web
{
  public class Database : DbContext
  {
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public Database(DbContextOptions<Database> options) : base(options) { }
  }
}
