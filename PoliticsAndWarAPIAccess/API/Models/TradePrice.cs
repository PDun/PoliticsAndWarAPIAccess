using PoliticsAndWarAPIAccess.Caching;

namespace PoliticsAndWarAPIAccess.API.Models
{
    public class TradePrice : CacheModel
    {
        public override int _id { get => this.GetHashCode(); }
        public string resource { get; set; }
        public string avgprice { get; set; }
        public string marketindex { get; set; }
        public TradePriceOffer highestbuy { get; set; }
        public TradePriceOffer lowestbuy { get; set; }
    }
}
