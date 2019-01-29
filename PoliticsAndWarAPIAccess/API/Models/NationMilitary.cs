using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class NationMilitary
  {
    public string nation_id { get; set; }
    public string vm_indicator { get; set; }
    public string score { get; set; }
    public string soldiers { get; set; }
    public string tanks { get; set; }
    public string aircraft { get; set; }
    public string ships { get; set; }
    public string missiles { get; set; }
    public string nukes { get; set; }
    public string alliance { get; set; }
    public int alliance_id { get; set; }
    public int alliance_position { get; set; }
  }
  public class NationMilitaryResponse
  {
    public bool success { get; set; }
    public List<NationMilitary> nation_militaries { get; set; }
  }
}
