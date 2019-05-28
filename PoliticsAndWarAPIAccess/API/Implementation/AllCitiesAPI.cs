using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
    public class AllCitiesAPI : ApiBase, IAllCitiesAPI
    {
        protected ICacheEngine<AllCity> _cacheEngine;
        public AllCitiesAPI(Environment env = Environment.Main, ICacheEngine<AllCity> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public AllCitiesAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<AllCityResponse> GetAllCities(string apiKey, Expression<Func<AllCity, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<AllCity> cache;
                if (expression != null)
                {
                    cache = await _cacheEngine.FindAsync(expression);
                }
                else
                {
                    cache = await _cacheEngine.GetAllAsync();
                }
                if (cache.Any())
                    return new AllCityResponse() { success = true, all_cities = cache.ToList() };
            }
            var result = await this.service.Get<AllCityResponse>($"/all-cities/key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.all_cities);
            return result;
        }
    }
}
