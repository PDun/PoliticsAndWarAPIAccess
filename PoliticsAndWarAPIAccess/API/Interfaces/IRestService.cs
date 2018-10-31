using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IRestService
  {
    Task<T> Get<T>(string resource) where T : class, new();
  }
}