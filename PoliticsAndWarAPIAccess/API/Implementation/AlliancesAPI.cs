using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class AlliancesAPI : ApiBase, IAlliancesAPI
  {
    public AlliancesAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public AlliancesAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<AlliancesResponse> GetAlliances(string apiKey)
    {
      return await this.service.Get<AlliancesResponse>($"/alliances/?key={apiKey}");
    }
  }
}
