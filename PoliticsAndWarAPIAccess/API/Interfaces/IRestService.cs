using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IRestService
  {
    Task<T> Get<T>(string resource, Dictionary<string, string> parameters = null) where T : class, new();
  }
}