namespace HFSclient.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public int LeagueId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public int LeagueSeason { get; set; }
    public string OwnerRole { get; set; }
    public string TeamName { get; set; }
    public virtual League League { get; set; }
  }
}