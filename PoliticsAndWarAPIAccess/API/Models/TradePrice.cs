namespace PoliticsAndWarAPIAccess.API.Models
{
  public class TradePrice
  {
    public string resource { get; set; }
    public string avgprice { get; set; }
    public string marketindex { get; set; }
    public TradePriceOffer highestbuy { get; set; }
    public TradePriceOffer lowestbuy { get; set; }
  }
}
