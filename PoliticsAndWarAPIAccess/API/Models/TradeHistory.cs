namespace PoliticsAndWarAPIAccess.API.Models
{
  public class TradeHistory
  {
    public string date { get; set; }
    public string offerer_nation_id { get; set; }
    public string accepter_nation_id { get; set; }
    public string resource { get; set; }
    public string offer_type { get; set; }
    public string quantity { get; set; }
    public string price { get; set; }
  }
}
