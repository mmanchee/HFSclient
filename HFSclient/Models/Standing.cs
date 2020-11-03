
namespace HFSclient.Models
{
  public class Standing
  {
    public int StandingId { get; set; }
    public int GroupId { get; set; }
    public int Wins { get; set; }
    public int Ties { get; set; }
    public int Losses { get; set; }
    public int PtsFor { get; set; }
    public int PtsAgst { get; set; }
  }
}