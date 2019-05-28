using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IAlliancesAPI
  {
    Task<AlliancesResponse> GetAlliances(string apiKey, Expression<Func<Alliances, bool>> expression = null, bool UseCache = true);
  }
}