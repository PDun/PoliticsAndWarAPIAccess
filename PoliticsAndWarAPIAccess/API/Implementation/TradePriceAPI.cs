using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class TradePriceAPI : ApiBase, ITradePriceAPI
  {
    public TradePriceAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public TradePriceAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<TradePrice> GetAlliance(Resources resource)
    {
      return await this.service.Get<TradePrice>($"tradeprice/resource={resource.ToString("g")}");
    }
  }
}
