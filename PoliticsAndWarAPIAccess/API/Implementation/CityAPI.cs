using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<City> GetCity(int CityId, string apiKey, Expression<Func<City, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<City> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression)).Where(x=> x._id == CityId);
                }
                else
                {
                    cache = await _cacheEngine.FindAsync(x => x._id == CityId);
                }
                if (cache.Any())
                    return cache.FirstOrDefault();
            }
            var result = await this.service.Get<City>($"/city/id={CityId}&key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result);
            return result;
        }
    }
}