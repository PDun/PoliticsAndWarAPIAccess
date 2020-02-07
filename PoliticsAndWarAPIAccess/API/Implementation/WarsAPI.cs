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
    public class WarsAPI : ApiBase, IWarsAPI
    {
        protected ICacheEngine<Wars> _cacheEngine;
        public WarsAPI(Environment env = Environment.Main, ICacheEngine<Wars> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public WarsAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<WarsResponse> GetWars(int? limit, string apiKey, Expression<Func<Wars, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<Wars> cache;
                if (expression != null)
                {
                    cache = await _cacheEngine.FindAsync(expression);
                }
                else
                {
                    cache = await _cacheEngine.GetAllAsync();
                }
                if (limit.HasValue)
                {
                    cache = cache.Take(limit.Value);
                }
                if (cache.Any())
                    return new WarsResponse() { success = true, wars = cache.ToList() };
            }
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("key", apiKey);
            if (limit != null && limit.HasValue)
            {
                parameters.Add("limit", limit.Value.ToString());
            }
            var result = await this.service.Get<WarsResponse>($"/wars/", parameters);
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.wars);
            if (expression != null)
            {
                var compExpr = expression.Compile();
                result.wars = result.wars.Where(x => compExpr(x)).ToList();
            }
            return result;
        }
    }
}
