namespace HFSclient.Models
{
  public class Week
  {
    public int WeekId { get; set; }
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