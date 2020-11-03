
namespace HFSclient.Models
{
  public class Standing
  {
    public int StandingId { get; set; }
<<<<<<< HEAD
    //public virtual ApplicationUser User { get; set; }
=======
>>>>>>> mm/standings
    public int GroupId { get; set; }
    public int Wins { get; set; }
    public int Ties { get; set; }
    public int Losses { get; set; }
    public int PtsFor { get; set; }
    public int PtsAgst { get; set; }
  }
}