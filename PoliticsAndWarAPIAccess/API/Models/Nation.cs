﻿using PoliticsAndWarAPIAccess.Caching;
using System.Collections.Generic;

namespace PoliticsAndWarAPIAccess.API.Models
{
    public class Nation : CacheModel
    {
        public override int _id { get => int.Parse(nationid); }
        public List<string> cityids { get; set; }
        public int cityprojecttimerturns { get; set; }
        public bool success { get; set; }
        public string nationid { get; set; }
        public string name { get; set; }
        public string prename { get; set; }
        public string continent { get; set; }
        public string socialpolicy { get; set; }
        public string color { get; set; }
        public int minutessinceactive { get; set; }
        public string uniqueid { get; set; }
        public string government { get; set; }
        public string domestic_policy { get; set; }
        public string war_policy { get; set; }
        public string founded { get; set; }
        public int daysold { get; set; }
        public string alliance { get; set; }
        public string allianceposition { get; set; }
        public string allianceid { get; set; }
        public string flagurl { get; set; }
        public string leadername { get; set; }
        public string title { get; set; }
        public string ecopolicy { get; set; }
        public string approvalrating { get; set; }
        public string nationrank { get; set; }
        public string nationrankstrings { get; set; }
        public int nrtotal { get; set; }
        public int cities { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string score { get; set; }
        public string population { get; set; }
        public string gdp { get; set; }
        public int totalinfrastructure { get; set; }
        public int landarea { get; set; }
        public string soldiers { get; set; }
        public string soldiercasualties { get; set; }
        public string soldierskilled { get; set; }
        public string tanks { get; set; }
        public string tankcasualties { get; set; }
        public string tankskilled { get; set; }
        public string aircraft { get; set; }
        public string aircraftcasualties { get; set; }
        public string aircraftkilled { get; set; }
        public string ships { get; set; }
        public string shipcasualties { get; set; }
        public string shipskilled { get; set; }
        public string missiles { get; set; }
        public string missilelaunched { get; set; }
        public string missileseaten { get; set; }
        public string nukes { get; set; }
        public string nukeslaunched { get; set; }
        public string nukeseaten { get; set; }
        public string infdesttot { get; set; }
        public string infraLost { get; set; }
        public string moneyLooted { get; set; }
        public string ironworks { get; set; }
        public string bauxiteworks { get; set; }
        public string armsstockpile { get; set; }
        public string emgasreserve { get; set; }
        public string massirrigation { get; set; }
        public string inttradecenter { get; set; }
        public string missilelpad { get; set; }
        public string nuclearresfac { get; set; }
        public string irondome { get; set; }
        public string vitaldefsys { get; set; }
        public string intagncy { get; set; }
        public string uraniumenrich { get; set; }
        public string propbureau { get; set; }
        public string cenciveng { get; set; }
        public string city_planning { get; set; }
        public string adv_city_planning { get; set; }
        public string space_program { get; set; }
        public string spy_satellite { get; set; }
        public string moon_landing { get; set; }
        public string green_technologies { get; set; }
        public string telecommunications_satellite { get; set; }
        public string recycling_initiative { get; set; }
        public string pirate_economy { get; set; }
        public string adv_engineering_corps { get; set; }
        public string arable_land_agency { get; set; }
        public string specialized_police_training { get; set; }
        public string clinical_research_center { get; set; }
        public string vmode { get; set; }
        public int offensivewars { get; set; }
        public int defensivewars { get; set; }
        public List<string> offensivewar_ids { get; set; }
        public List<string> defensivewar_ids { get; set; }
        public int beige_turns_left { get; set; }
        public double radiation_index { get; set; }
        public string season { get; set; }
    }
}
