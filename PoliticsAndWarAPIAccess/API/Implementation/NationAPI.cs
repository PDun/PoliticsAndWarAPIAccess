using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class NationAPI : ApiBase, INationAPI
  {
    public NationAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public NationAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<Nation> GetNation(int NationId,string apiKey)
    {
      return await this.service.Get<Nation>($"/nation/id={NationId}&key={apiKey}");
    }
  }
}
