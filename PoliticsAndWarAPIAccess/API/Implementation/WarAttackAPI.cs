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
    public class WarAttackAPI : ApiBase, IWarAttackAPI
    {
        protected ICacheEngine<WarAttack> _cacheEngine;
        public WarAttackAPI(Environment env = Environment.Main, ICacheEngine<WarAttack> cacheEngine = null) : base(env)
        {
            this._cacheEngine = cacheEngine;
        }
        public WarAttackAPI(IRestService _service) : base(_service)
        {
        }
        public async Task<WarAttackResponse> GetWarAttack(string key, int warId = 0, int minWarAttackId = 0, int maxWarAttackId = 0, Expression<Func<WarAttack, bool>> expression = null, bool UseCache = true)
        {
            if (_cacheEngine != null && UseCache)
            {
                IEnumerable<WarAttack> cache;
                if (expression != null)
                {
                    cache = (await _cacheEngine.FindAsync(expression));
                }
                else
                {
                    cache = (await _cacheEngine.GetAllAsync());
                }
                if (warId > 0)
                {
                    cache = cache.Where(x=> int.Parse(x.war_id) == warId);
                }
                else
                {
                    if (minWarAttackId > 0)
                    {
                        cache = cache.Where(x=> minWarAttackId >= int.Parse(x.war_attack_id));
                    }
                    if (maxWarAttackId > 0)
                    {
                        cache = cache.Where(x => maxWarAttackId <= int.Parse(x.war_attack_id));
                    }
                }
                if (cache.Any())
                    return new WarAttackResponse() { success = true, war_attacks = cache.ToList() };
            }
            string path = $"/war-attacks/key={key}";
            if (warId > 0)
            {
                path += $"&war_id={warId}";
            }
            else
            {
                if (minWarAttackId > 0)
                {
                    path += $"&min_war_attack_id={minWarAttackId}";
                }
                if (maxWarAttackId > 0)
                {
                    path += $"&max_war_attack_id={maxWarAttackId}";
                }
            }
            var result = await this.service.Get<WarAttackResponse>(path);
            if (_cacheEngine != null && result.success)
                await _cacheEngine.Build(result.war_attacks);
            return result;
        }
    }
}
