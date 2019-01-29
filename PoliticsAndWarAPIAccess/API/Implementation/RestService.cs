using PoliticsAndWarAPIAccess.API.Interfaces;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class RestService : IRestService
  {
    private IRestClient _client;
    /// <summary>
    /// Creates a RestService for calling REST API
    /// </summary>
    /// <param name="baseUrl">Base URL
    /// @"https://politicsandwar.com/api" for Main Server
    /// @"https://test.politicsandwar.com/api" for Test Server
    /// </param>
    public RestService(string baseUrl)
    {
      _client = new RestClient(baseUrl);
    }

    /// <summary>
    /// Gets the resource and serializes it to the generic type
    /// </summary>
    /// <typeparam name="T">Model for the response to be serialized to</typeparam>
    /// <param name="resource">resource for the request</param>
    /// <returns>Task of the generic type sent in</returns>
    public async Task<T> Get<T>(string resource, Dictionary<string,string> parameters = null) where T : class, new()
    {
      var request = new RestRequest(resource);
      if (parameters != null && parameters.Any())
      {
        foreach (KeyValuePair<string,string> kvp in parameters)
        {
          request.AddQueryParameter(kvp.Key, kvp.Value);
        }
      }
      var cancellationTokenSource = new CancellationTokenSource();
      request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
      IRestResponse<T> response = await _client.ExecuteTaskAsync<T>(request, cancellationTokenSource.Token);
      return response.Data;
    }
  }
}
