using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IAllCitiesAPI
  {
    Task<AllCityResponse> GetAllCities(string apiKey);
  }
}