using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HFSclient.Models
{
  public class HFSclientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Group> Groups { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Roster> Rosters { get; set; }
    public DbSet<Week> Weeks { get; set; }
    public HFSclientContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}