using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class NationsAPI : ApiBase, INationsAPI
  {
    public NationsAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public NationsAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<NationsResponse> GetNations(bool? vm = null, int? allianceId = null, int? min_score = null, int? max_score = null)
    {
      Dictionary<string, string> parameters = new Dictionary<string, string>();
      if (vm != null && vm.HasValue)
      {
        parameters.Add("vm", vm.Value.ToString().ToLower());
      }
      if (allianceId != null && allianceId.HasValue)
      {
        parameters.Add("alliance_id", allianceId.Value.ToString());
      }
      if (min_score != null && min_score.HasValue)
      {
        parameters.Add("min_score", min_score.Value.ToString());
      }
      if (max_score != null && max_score.HasValue)
      {
        parameters.Add("max_score", max_score.Value.ToString());
      }
      return await this.service.Get<NationsResponse>($"/nations/", parameters);
    }
  }
}
