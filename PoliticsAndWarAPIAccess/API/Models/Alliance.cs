using PoliticsAndWarAPIAccess.Caching;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace PoliticsAndWarAPIAccess.API.Models
{
    public class Alliance : CacheModel
    {
        public override int _id { get => int.Parse(allianceid); }
        public List<int> leaderids { get; set; }
        public bool success { get; set; }
        public string allianceid { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public string score { get; set; }
        public string color { get; set; }
        public int members { get; set; }
        public List<int> member_id_list { get; set; }
        public int vmodemembers { get; set; }
        [DeserializeAs(Name = "accepting members")]
        public string accepting_members { get; set; }
        public int applicants { get; set; }
        public string flagurl { get; set; }
        public string forumurl { get; set; }
        public string irc { get; set; }
        public double gdp { get; set; }
        public int cities { get; set; }
        public int soldiers { get; set; }
        public int tanks { get; set; }
        public int aircraft { get; set; }
        public int ships { get; set; }
        public int missiles { get; set; }
        public int nukes { get; set; }
        public int treasures { get; set; }
    }
}
