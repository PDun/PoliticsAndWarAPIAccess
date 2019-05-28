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
    public class NationMilitaryAPI : ApiBase, INationMilitaryAPI
    {
        protected ICacheEngine<NationMilitary> _cacheEngine;
        public NationMilitaryAPI(Environment env = Environment.Main, ICacheEngine<NationMilitary> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public NationMilitaryAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<NationMilitaryResponse> GetNationMilitary(string apiKey, Expression<Func<NationMilitary, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<NationMilitary> cache;
                if (expression != null)
                {
                    cache = await _cacheEngine.FindAsync(expression);
                }
                else
                {
                    cache = await _cacheEngine.GetAllAsync();
                }
                if (cache.Any())
                    return new NationMilitaryResponse() { success = true, nation_militaries = cache.ToList() };
            }
            var result = await this.service.Get<NationMilitaryResponse>($"/nation-military/key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.nation_militaries);
            return result;
        }
    }
}
