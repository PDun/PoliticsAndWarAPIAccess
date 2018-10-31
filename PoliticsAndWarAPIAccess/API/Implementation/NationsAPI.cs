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
    public async Task<NationsResponse> GetNations()
    {
      return await this.service.Get<NationsResponse>($"/nations/");
    }
  }
}
