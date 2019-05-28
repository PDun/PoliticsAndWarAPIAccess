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
    public class AlliancesAPI : ApiBase, IAlliancesAPI
    {
        protected ICacheEngine<Alliances> _cacheEngine;
        public AlliancesAPI(Environment env = Environment.Main, ICacheEngine<Alliances> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public AlliancesAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<AlliancesResponse> GetAlliances(string apiKey, Expression<Func<Alliances, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<Alliances> cache;
                if (expression != null)
                {
                    cache = await _cacheEngine.FindAsync(expression);
                }
                else
                {
                    cache = await _cacheEngine.GetAllAsync();
                }
                if (cache.Any())
                    return new AlliancesResponse() { success = true, alliances = cache.ToList() };
            }
            var result = await this.service.Get<AlliancesResponse>($"/alliances/?key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.alliances);
            return result;
        }
    }
}
