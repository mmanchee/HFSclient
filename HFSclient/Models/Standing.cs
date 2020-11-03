namespace HFSclient.Models
{
  public class Standing
  {
    public int StandingId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public int GroupId { get; set; }
    public int Wins { get; set; }
    public int Ties { get; set; }
    public int Losses { get; set; }
  }
}