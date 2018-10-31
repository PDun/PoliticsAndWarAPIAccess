using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class AlliancesResponse
  {
    public bool success { get; set; }
    public List<Alliances> alliances { get; set; }
  }
}
