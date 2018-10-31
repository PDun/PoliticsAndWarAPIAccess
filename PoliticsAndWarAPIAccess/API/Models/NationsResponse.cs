using System.Collections.Generic;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class NationsResponse
  {
    public bool success { get; set; }
    public List<Nations> nations { get; set; }
  }
}
