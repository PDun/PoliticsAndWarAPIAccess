using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IAllCitiesAPI
  {
    Task<AllCityResponse> GetAllCities(string apiKey, Expression<Func<AllCity, bool>> expression = null, bool UseCache = true);
  }
}