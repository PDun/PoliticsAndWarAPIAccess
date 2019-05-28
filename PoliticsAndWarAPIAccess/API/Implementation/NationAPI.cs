using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
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
        public async Task<Nation> GetNation(int NationId, string apiKey)
        {
            var result = await this.service.Get<Nation>($"/nation/id={NationId}&key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result);
            return result;
        }
    }
}
