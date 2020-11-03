namespace HFSclient.Models
{
  public class Schedule
  {
    public int ScheduleId { get; set; }
    public virtual ApplicationUser User1 { get; set; }
    public virtual ApplicationUser User2 { get; set; }
    public int GroupId { get; set; }
    public int Week { get; set; }
    public int Winner { get; set; }
  }
}