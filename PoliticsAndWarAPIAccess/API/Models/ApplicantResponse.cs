using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class ApplicantResponse
  {
    public bool success { get; set; }
    public List<Applicant> nations { get; set; }
  }
}
