using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IWarAPI
  {
    Task<WarResponse> GetWar(int id, string apiKey, Expression<Func<War, bool>> expression = null, bool UseCache = true);
  }
}