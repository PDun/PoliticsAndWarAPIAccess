using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class TradeHistoryAPI : ApiBase, ITradeHistoryAPI
  {
    public TradeHistoryAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public TradeHistoryAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<TradeHistoryResponse> GetTradeHistory(string apiKey, Resources[] resources, int records = 10000)
    {
      return await this.service.Get<TradeHistoryResponse>($"/trade-history/key={apiKey}&resources={string.Join(",",resources.Select(x=> x.ToString("g")))}&records={records}");
    }
  }
}
