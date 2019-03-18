using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class AllianceAPI : ApiBase, IAllianceAPI
  {
    public AllianceAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public AllianceAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<Alliance> GetAlliance(int id,string apikey)
    {
      return await this.service.Get<Alliance>($"/alliance/id={id}&key={apikey}");
    }
  }
}
