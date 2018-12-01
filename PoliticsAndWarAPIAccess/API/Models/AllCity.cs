using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class AllCity
  {
    public string nation_id { get; set; }
    public string city_id { get; set; }
    public string city_name { get; set; }
    public string capital { get; set; }
    public string infrastructure { get; set; }
    public string maxinfra { get; set; }
    public string land { get; set; }
  }
}
