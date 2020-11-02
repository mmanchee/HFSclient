using System.Collections.Generic;

namespace HFSclient.Models
{
  public class Owner
  {
    public Owner()
    {
      this.Groups = new HashSet<Group>();
    }
    public int OwnerId { get; set; }
    public string OwnerName { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<Group> Groups { get; }  
  }
}