using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
    public class CityAPI : ApiBase, ICityAPI
    {
        protected ICacheEngine<City> _cacheEngine;
        public CityAPI(Environment env = Environment.Main, ICacheEngine<City> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public CityAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<City> GetCity(int CityId, string apiKey)
        {
            var result = await this.service.Get<City>($"/city/id={CityId}&key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result);
            return result;
        }
    }
}