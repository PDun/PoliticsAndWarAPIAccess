using System.Collections.Generic;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class WarResponse
  {
    public bool success { get; set; }
    public List<War> war { get; set; }
  }
}
