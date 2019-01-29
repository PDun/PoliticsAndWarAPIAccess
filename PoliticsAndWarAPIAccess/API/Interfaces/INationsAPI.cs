using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface INationsAPI
  {
    Task<NationsResponse> GetNations(bool? vm = null, int? allianceId = null, int? min_score = null, int? max_score = null);
  }
}