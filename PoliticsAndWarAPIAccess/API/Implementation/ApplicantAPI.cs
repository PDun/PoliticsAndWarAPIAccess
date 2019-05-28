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
        public async Task<ApplicantResponse> GetApplicant(int AllianceId, string apiKey, Expression<Func<Applicant, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<Applicant> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression)).Where(x => x.AllianceId == AllianceId);
                }
                else
                {
                    cache = await _cacheEngine.GetAllAsync();
                }
                if (cache.Any())
                    return new ApplicantResponse() { success = true, nations = cache.ToList() };
            }
            var result = await this.service.Get<ApplicantResponse>($"/applicants/{AllianceId}&key={apiKey}");
            if (result.success)
            {
                foreach (var nation in result.nations)
                {
                    nation.AllianceId = AllianceId;
                }
            }
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.nations);
            return result;
        }
    }
}
