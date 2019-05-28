using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
    public class Alliances : CacheModel
    {
        public override int _id { get => int.Parse(id); }
        public string id { get; set; }
        public string founddate { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public string color { get; set; }
        public string continent { get; set; }
        public int rank { get; set; }
        public int members { get; set; }
        public double score { get; set; }
        public List<string> officerids { get; set; }
        public List<string> leaderids { get; set; }
        public List<string> heirids { get; set; }
        public double avgscore { get; set; }
        public string flagurl { get; set; }
        public string forumurl { get; set; }
        public string ircchan { get; set; }
    }
}
