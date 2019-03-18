﻿using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Collections.Generic;
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
    public async Task<WarsResponse> GetWars(int? limit,string apiKey)
    {

      Dictionary<string, string> parameters = new Dictionary<string, string>();
      parameters.Add("key", apiKey);
      if (limit != null && limit.HasValue)
      {
        parameters.Add("limit", limit.Value.ToString());
      }
      return await this.service.Get<WarsResponse>($"/wars/",parameters);
    }
  }
}
