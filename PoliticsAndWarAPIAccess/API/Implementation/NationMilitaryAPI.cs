using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<NationMilitaryResponse> GetNationMilitary(string apiKey)
        {
            var result = await this.service.Get<NationMilitaryResponse>($"/nation-military/key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.nation_militaries);
            return result;
        }
    }
}
