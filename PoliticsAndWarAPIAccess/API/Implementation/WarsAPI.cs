using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class WarsAPI : ApiBase, IWarsAPI
  {
    public WarsAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public WarsAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<WarsResponse> GetWars(int limit)
    {
      return await this.service.Get<WarsResponse>($"wars/{limit}");
    }
  }
}
