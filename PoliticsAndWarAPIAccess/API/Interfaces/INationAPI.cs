using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface INationAPI
  {
    Task<Nation> GetNation(int NationId, string apiKey, Expression<Func<Nation, bool>> expression = null, bool UseCache = true);
  }
}