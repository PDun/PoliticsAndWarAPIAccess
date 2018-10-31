using System;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class Wars
  {
    public int warID { get; set; }
    public int attackerID { get; set; }
    public int defenderID { get; set; }
    public string attackerAA { get; set; }
    public string defenderAA { get; set; }
    public string war_type { get; set; }
    public string status { get; set; }
    public DateTime date { get; set; }
  }
}
