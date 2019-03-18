using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface ICityAPI
  {
    Task<City> GetCity(int CityId, string apiKey);
  }
}