namespace HFSclient.Models
{
  public class Tracker
  {
    public int TrackerId { get; set; }
    public int GroupId { get; set; }
    public int GameId { get; set; }
    public int PlayerId { get; set; }
    public int ScheduleId { get; set; }
    public string Position { get; set; } // Owner positions
    public int Points { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
  }
}