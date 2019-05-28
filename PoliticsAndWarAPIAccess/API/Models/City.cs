using PoliticsAndWarAPIAccess.Caching;

namespace PoliticsAndWarAPIAccess.API.Models
{
    public class City : CacheModel
    {
        public override int _id { get => int.Parse(cityid); }
        public bool success { get; set; }
        public string cityid { get; set; }
        public string url { get; set; }
        public string nationid { get; set; }
        public string name { get; set; }
        public string nation { get; set; }
        public string leader { get; set; }
        public string continent { get; set; }
        public string founded { get; set; }
        public int age { get; set; }
        public string powered { get; set; }
        public string infrastructure { get; set; }
        public string land { get; set; }
        public double population { get; set; }
        public double popdensity { get; set; }
        public int crime { get; set; }
        public double disease { get; set; }
        public int commerce { get; set; }
        public double avgincome { get; set; }
        public int pollution { get; set; }
        public int nuclearpollution { get; set; }
        public int basepop { get; set; }
        public double basepopdensity { get; set; }
        public double minimumwage { get; set; }
        public double poplostdisease { get; set; }
        public int poplostcrime { get; set; }
        public string imp_coalpower { get; set; }
        public string imp_oilpower { get; set; }
        public string imp_nuclearpower { get; set; }
        public string imp_windpower { get; set; }
        public string imp_coalmine { get; set; }
        public string imp_oilwell { get; set; }
        public string imp_ironmine { get; set; }
        public string imp_bauxitemine { get; set; }
        public string imp_leadmine { get; set; }
        public string imp_uramine { get; set; }
        public string imp_farm { get; set; }
        public string imp_gasrefinery { get; set; }
        public string imp_steelmill { get; set; }
        public string imp_aluminumrefinery { get; set; }
        public string imp_munitionsfactory { get; set; }
        public string imp_policestation { get; set; }
        public string imp_hospital { get; set; }
        public string imp_recyclingcenter { get; set; }
        public string imp_subway { get; set; }
        public string imp_supermarket { get; set; }
        public string imp_bank { get; set; }
        public string imp_mall { get; set; }
        public string imp_stadium { get; set; }
        public string imp_barracks { get; set; }
        public string imp_factory { get; set; }
        public string imp_hangar { get; set; }
        public string imp_drydock { get; set; }
    }
}
