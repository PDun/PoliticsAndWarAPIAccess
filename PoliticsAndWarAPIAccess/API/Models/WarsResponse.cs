using System.Collections.Generic;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class WarsResponse
  {
    public bool success { get; set; }
    public List<Wars> wars { get; set; }
  }
}
