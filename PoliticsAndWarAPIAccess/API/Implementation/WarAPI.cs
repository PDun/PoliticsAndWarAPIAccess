using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class WarAPI : ApiBase, IWarAPI
  {
    public WarAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public WarAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<WarResponse> GetWar(int id)
    {
      return await this.service.Get<WarResponse>($"/war/{id}");
    }
  }
}
