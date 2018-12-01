using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class AllCityResponse
  {
    public bool success { get; set; }
    public List<AllCity> all_cities { get; set; }
  }
}
