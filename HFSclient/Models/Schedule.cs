namespace HFSclient.Models
{
  public class Schedule
  {
    public int ScheduleId { get; set; }
    public int GroupId1 { get; set; }
    public int GroupId2 { get; set; }
    public int Week { get; set; }
    public int Team1Score { get; set; } 
    public int Team2Score { get; set; } 
    public bool IsComplete { get; set; }
    //might need league id
    //public int LeagueId { get; set; }
  }
}