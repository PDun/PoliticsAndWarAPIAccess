using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IAllianceAPI
  {
    Task<Alliance> GetAlliance(int id, string apiKey, Expression<Func<Alliance, bool>> expression = null, bool UseCache = true);
  }
}