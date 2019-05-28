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
    public class ApplicantAPI : ApiBase, IApplicantAPI
    {
        protected ICacheEngine<Applicant> _cacheEngine;
        public ApplicantAPI(Environment env = Environment.Main, ICacheEngine<Applicant> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public ApplicantAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<ApplicantResponse> GetApplicant(int AllianceId, string apiKey)
        {
            var result = await this.service.Get<ApplicantResponse>($"/applicants/{AllianceId}&key={apiKey}");
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.nations);
            return result;
        }
    }
}
