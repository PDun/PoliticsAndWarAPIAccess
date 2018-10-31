using System;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class War
  {
    public bool war_ended { get; set; }
    public DateTime date { get; set; }
    public string aggressor_id { get; set; }
    public string defender_id { get; set; }
    public string aggressor_alliance_name { get; set; }
    public bool aggressor_is_applicant { get; set; }
    public string defender_alliance_name { get; set; }
    public bool defender_is_applicant { get; set; }
    public bool aggressor_offering_peace { get; set; }
    public string war_reason { get; set; }
    public string ground_control { get; set; }
    public string air_superiority { get; set; }
    public string blockade { get; set; }
    public string aggressor_military_action_points { get; set; }
    public string defender_military_action_points { get; set; }
    public string aggressor_resistance { get; set; }
    public string defender_resistance { get; set; }
    public bool aggressor_is_fortified { get; set; }
    public bool defender_is_fortified { get; set; }
    public int turns_left { get; set; }
    public string war_type { get; set; }
    public int aggressor_infra_lost { get; set; }
    public int defender_infra_lost { get; set; }
    public int aggressor_money_lost { get; set; }
    public int defender_money_lost { get; set; }
    public int aggressor_soldiers_lost { get; set; }
    public int defender_soldiers_lost { get; set; }
    public int aggressor_tanks_lost { get; set; }
    public int defender_tanks_lost { get; set; }
    public int aggressor_aircraft_lost { get; set; }
    public int defender_aircraft_lost { get; set; }
    public int aggressor_ships_lost { get; set; }
    public int defender_ships_lost { get; set; }
  }
}
