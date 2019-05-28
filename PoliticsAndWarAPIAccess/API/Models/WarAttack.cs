using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
    public class WarAttack : CacheModel
    {
        public override int _id { get => int.Parse(this.war_attack_id); }
        public string war_attack_id { get; set; }
        public string date { get; set; }
        public string war_id { get; set; }
        public string attacker_nation_id { get; set; }
        public string defender_nation_id { get; set; }
        public string attack_type { get; set; }
        public string victor { get; set; }
        public string success { get; set; }
        public string attcas1 { get; set; }
        public string attcas2 { get; set; }
        public string defcas1 { get; set; }
        public string defcas2 { get; set; }
        public string city_id { get; set; }
        public string infra_destroyed { get; set; }
        public string improvements_destroyed { get; set; }
        public string money_looted { get; set; }
        public string note { get; set; }
        public string city_infra_before { get; set; }
        public string infra_destroyed_value { get; set; }
        public string att_gas_used { get; set; }
        public string att_mun_used { get; set; }
        public string def_gas_used { get; set; }
        public string def_mun_used { get; set; }
    }
}
