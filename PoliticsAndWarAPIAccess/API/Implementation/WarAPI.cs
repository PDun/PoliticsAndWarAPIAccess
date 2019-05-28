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
    public class WarAPI : ApiBase, IWarAPI
    {
        protected ICacheEngine<War> _cacheEngine;
        public WarAPI(Environment env = Environment.Main, ICacheEngine<War> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public WarAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<WarResponse> GetWar(int id, string apiKey, Expression<Func<War, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<War> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression)).ToList().Where(x=> x._id == id);
                }
                else
                {
                    cache = await _cacheEngine.FindAsync(x=> x._id == id).ToList();
                }
                if (cache.Any())
                    return new WarResponse() { success = true, war = cache.ToList() };
            }
            var result = await this.service.Get<WarResponse>($"/war/{id}&key={apiKey}");
            if (result.success)
                result.war.First().war_id = id;
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.war);
            return result;
        }
    }
}
