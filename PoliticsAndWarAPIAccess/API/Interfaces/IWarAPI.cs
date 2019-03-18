using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IWarAPI
  {
    Task<WarResponse> GetWar(int id, string apiKey);
  }
}