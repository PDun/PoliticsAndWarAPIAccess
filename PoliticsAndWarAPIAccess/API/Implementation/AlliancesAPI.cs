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
        public async Task<AlliancesResponse> GetAlliances(string apiKey)
        {
            var result = await this.service.Get<AlliancesResponse>($"/alliances/?key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.alliances);
            return result;
        }
    }
}
