using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class NationMilitaryAPI : ApiBase, INationMilitaryAPI
  {
    public NationMilitaryAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public NationMilitaryAPI(IRestService _service) : base(_service)
    {
    }
    public async Task<NationMilitaryResponse> GetNationMilitary(string apiKey)
    {
      return await this.service.Get<NationMilitaryResponse>($"/nation-military/key={apiKey}");
    }
  }
}
