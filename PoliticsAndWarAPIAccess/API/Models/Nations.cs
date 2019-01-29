namespace PoliticsAndWarAPIAccess.API.Models
{
  public class Nations
  {
    public int nationid { get; set; }
    public string nation { get; set; }
    public string leader { get; set; }
    public string continent { get; set; }
    public string war_policy { get; set; }
    public string color { get; set; }
    public string alliance { get; set; }
    public int allianceid { get; set; }
    public int allianceposition { get; set; }
    public int cities { get; set; }
    public int offensivewars { get; set; }
    public int defensivewars { get; set; }
    public double score { get; set; }
    public int rank { get; set; }
    public string vacmode { get; set; }
    public int minutessinceactive { get; set; }
  }
}
