namespace HFSclient.Models
{
  public class Tracker
  {
    public int TrackerId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public int GroupWeek { get; set; }
    public int GroupId { get; set; }
    public int PlayerId { get; set; }
    public string Position { get; set; }
    public int GameWeek { get; set; }
    public int GameSeason { get; set; }
    public int Points { get; set; }   
  }
}