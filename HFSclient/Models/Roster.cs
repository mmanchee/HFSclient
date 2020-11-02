namespace HFSclient.Models
{
  public class Roster
  {
    public int RosterId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public int PlayerId { get; set; }
    public int GroupId { get; set; }  
  }
}