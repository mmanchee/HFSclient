namespace HFSclient.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public int LeagueId { get; set; }
    public int OwnerId { get; set; }
    public int LeagueSeason { get; set; }
    public string OwnerRole { get; set; }
  }
}