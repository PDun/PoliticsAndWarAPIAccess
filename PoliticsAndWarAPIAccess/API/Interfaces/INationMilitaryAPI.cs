using PoliticsAndWarAPIAccess.API.Models;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public interface INationMilitaryAPI
  {
    Task<NationMilitaryResponse> GetNationMilitary(string apiKey);
  }
}