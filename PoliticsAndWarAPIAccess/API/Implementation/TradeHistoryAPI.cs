using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
    public class TradeHistoryAPI : ApiBase, ITradeHistoryAPI
    {
        protected ICacheEngine<TradeHistory> _cacheEngine;
        public TradeHistoryAPI(Environment env = Environment.Main, ICacheEngine<TradeHistory> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public TradeHistoryAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<TradeHistoryResponse> GetTradeHistory(string apiKey, Resources[] resources, int records = 10000, Expression<Func<TradeHistory, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<TradeHistory> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression)).Where(x => resources.Any(y => y.ToString() == x.resource)).Take(records);
                }
                else
                {
                    cache = (await _cacheEngine.GetAllAsync()).Where(x=> resources.Any(y=> y.ToString()== x.resource)).Take(records);
                }
                if (cache.Any())
                    return new TradeHistoryResponse() { success = true, trades = cache.ToList() };
            }
            var result = await this.service.Get<TradeHistoryResponse>($"/trade-history/key={apiKey}&resources={string.Join(",", resources.Select(x => x.ToString("g")))}&records={records}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.trades);
            if (expression != null)
            {
                var compExpr = expression.Compile();
                result.trades = result.trades.Where(x => compExpr(x)).ToList();
            }
            return result;
        }
    }
}
