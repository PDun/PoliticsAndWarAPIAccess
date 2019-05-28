using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IWarsAPI
  {
    Task<WarsResponse> GetWars(int? limit, string apiKey, Expression<Func<Wars, bool>> expression = null, bool UseCache = true);
  }
}