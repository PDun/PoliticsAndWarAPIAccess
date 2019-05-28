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
    public class NationsAPI : ApiBase, INationsAPI
    {
        protected ICacheEngine<Nations> _cacheEngine;
        public NationsAPI(Environment env = Environment.Main, ICacheEngine<Nations> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public NationsAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<NationsResponse> GetNations(string apiKey, bool? vm = null, int? allianceId = null, int? min_score = null, int? max_score = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("key", apiKey);
            if (vm != null && vm.HasValue)
            {
                parameters.Add("vm", vm.Value.ToString().ToLower());
            }
            if (allianceId != null && allianceId.HasValue)
            {
                parameters.Add("alliance_id", allianceId.Value.ToString());
            }
            if (min_score != null && min_score.HasValue)
            {
                parameters.Add("min_score", min_score.Value.ToString());
            }
            if (max_score != null && max_score.HasValue)
            {
                parameters.Add("max_score", max_score.Value.ToString());
            }

            var result = await this.service.Get<NationsResponse>($"/nations/", parameters);
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.nations);
            return result;

        }
    }
}
