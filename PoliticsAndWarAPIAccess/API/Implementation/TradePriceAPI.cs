using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
    public class TradePriceAPI : ApiBase, ITradePriceAPI
    {
        protected ICacheEngine<TradePrice> _cacheEngine;
        public TradePriceAPI(Environment env = Environment.Main, ICacheEngine<TradePrice> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public TradePriceAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<TradePrice> GetTradePrice(Resources resource, string apiKey)
        {
            var result = await this.service.Get<TradePrice>($"/tradeprice/resource={resource.ToString("g")}&key={apiKey}");
            if (_cacheEngine != null && result != null)
                await _cacheEngine.Build(result);
            return result;
        }
    }
}
