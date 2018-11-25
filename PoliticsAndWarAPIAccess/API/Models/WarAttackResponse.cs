using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class WarAttackResponse
  {
    public bool success { get; set; }
    public List<WarAttack> war_attacks { get; set; }
  }
}
