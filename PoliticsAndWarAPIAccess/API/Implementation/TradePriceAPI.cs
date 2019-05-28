using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<TradePrice> GetTradePrice(Resources resource, string apiKey, Expression<Func<TradePrice, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<TradePrice> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression)).ToList().Where(x => x.resource.Equals(resource.ToString(), StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    cache = await _cacheEngine.FindAsync(x=> x.resource.Equals(resource.ToString(),StringComparison.InvariantCultureIgnoreCase));
                }
                if (cache.Any())
                    return cache.ToList().OrderByDescending(x=> x.CreatedDate).FirstOrDefault();
            }
            var result = await this.service.Get<TradePrice>($"/tradeprice/resource={resource.ToString("g")}&key={apiKey}");
            if (_cacheEngine != null && result != null)
                await _cacheEngine.Build(result);
            return result;
        }
    }
}
