using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface INationsAPI
  {
    Task<NationsResponse> GetNations();
  }
}