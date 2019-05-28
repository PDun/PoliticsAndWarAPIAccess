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
    public class NationAPI : ApiBase, INationAPI
    {
        protected ICacheEngine<Nation> _cacheEngine;
        public NationAPI(Environment env = Environment.Main, ICacheEngine<Nation> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public NationAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<Nation> GetNation(int NationId, string apiKey, Expression<Func<Nation, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<Nation> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression)).ToList().Where(x => x._id == NationId);
                }
                else
                {
                    cache = await _cacheEngine.FindAsync(x => x._id == NationId);
                }
                if (cache.Any())
                    return cache.FirstOrDefault();
            }
            var result = await this.service.Get<Nation>($"/nation/id={NationId}&key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result);
            return result;
        }
    }
}
