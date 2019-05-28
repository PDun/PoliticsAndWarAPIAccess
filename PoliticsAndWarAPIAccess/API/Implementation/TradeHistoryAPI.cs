using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<TradeHistoryResponse> GetTradeHistory(string apiKey, Resources[] resources, int records = 10000)
        {
            var result = await this.service.Get<TradeHistoryResponse>($"/trade-history/key={apiKey}&resources={string.Join(",", resources.Select(x => x.ToString("g")))}&records={records}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.trades);
            return result;
        }
    }
}
