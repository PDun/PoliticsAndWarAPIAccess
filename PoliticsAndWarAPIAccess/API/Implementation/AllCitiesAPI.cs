using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class AllCitiesAPI : ApiBase, IAllCitiesAPI
  {
    public AllCitiesAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public AllCitiesAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<AllCityResponse> GetAllCities(string apiKey)
    {
      return await this.service.Get<AllCityResponse>($"/all-cities/key={apiKey}");
    }
  }
}
