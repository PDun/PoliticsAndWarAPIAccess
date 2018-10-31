using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class Applicant
  {
    public int nationid { get; set; }
    public string nation { get; set; }
    public string leader { get; set; }
    public string continent { get; set; }
    public int cities { get; set; }
    public int score { get; set; }
  }
}
