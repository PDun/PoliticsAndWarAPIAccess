using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IWarsAPI
  {
    Task<WarsResponse> GetWars(int? limit, string apiKey);
  }
}