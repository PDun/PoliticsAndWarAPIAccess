using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IApplicantAPI
  {
    Task<ApplicantResponse> GetApplicant(int AllianceId, string apiKey, Expression<Func<Applicant, bool>> expression = null, bool UseCache = true);
  }
}