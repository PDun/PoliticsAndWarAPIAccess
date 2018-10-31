using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface INationAPI
  {
    Task<Nation> GetNation(int NationId);
  }
}