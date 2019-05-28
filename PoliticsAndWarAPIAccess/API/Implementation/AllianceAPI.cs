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
    public class AllianceAPI : ApiBase, IAllianceAPI
    {
        protected ICacheEngine<Alliance> _cacheEngine;
        public AllianceAPI(Environment env = Environment.Main, ICacheEngine<Alliance> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public AllianceAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<Alliance> GetAlliance(int id, string apikey, Expression<Func<Alliance, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<Alliance> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression)).ToList().Where( x=> x._id == id);

                }
                else
                {
                    cache = await _cacheEngine.FindAsync(x => x._id == id).ToList();
                }
                if (cache.Any())
                    return  cache.FirstOrDefault();
            }
            var result = await this.service.Get<Alliance>($"/alliance/id={id}&key={apikey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result);
            return result;
        }
    }
}
