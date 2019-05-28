using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System.Linq;
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
        public async Task<WarResponse> GetWar(int id, string apiKey)
        {
            var result = await this.service.Get<WarResponse>($"/war/{id}&key={apiKey}");
            if (result.success)
                result.war.First().war_id = id;
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.war);
            return result;
        }
    }
}
