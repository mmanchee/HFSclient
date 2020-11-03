using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HFSclient.Models
{
  public class HFSclientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Group> Groups { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Tracker> Trackers { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public HFSclientContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}