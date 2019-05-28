using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public interface INationMilitaryAPI
  {
    Task<NationMilitaryResponse> GetNationMilitary(string apiKey, Expression<Func<NationMilitary, bool>> expression = null, bool UseCache = true);
  }
}