using Microsoft.EntityFrameworkCore;

namespace Restaurants.Models
{
  public class RestaurantsContext : DbContext
  {
    public DbSet<>  { get; set; } //update this
    public DbSet<>  { get; set; } //update this

    public RestaurantsContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}