using PoliticsAndWarAPIAccess.API.Interfaces;
using PoliticsAndWarAPIAccess.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
  public class ApplicantAPI : ApiBase, IApplicantAPI
  {
    public ApplicantAPI(Environment env = Environment.Main) : base(env)
    {
    }
    public ApplicantAPI(IRestService _service) : base (_service)
    {
    }
    public async Task<ApplicantResponse> GetNation(int AllianceId)
    {
      return await this.service.Get<ApplicantResponse>($"applicants/{AllianceId}");
    }
  }
}
