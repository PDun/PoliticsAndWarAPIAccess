using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface INationsAPI
  {
    Task<NationsResponse> GetNations(string apiKey,bool? vm = null, int? allianceId = null, int? min_score = null, int? max_score = null, Expression<Func<Nations, bool>> expression = null, bool UseCache = true);
  }
}