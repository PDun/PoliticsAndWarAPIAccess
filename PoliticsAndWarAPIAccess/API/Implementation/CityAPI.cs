using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class CityAPI : ApiBase, ICityAPI
  {
    public CityAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public CityAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<City> GetCity(int CityId,string apiKey)
    {
      return await this.service.Get<City>($"/city/id={CityId}&key={apiKey}");
    }
  }
}