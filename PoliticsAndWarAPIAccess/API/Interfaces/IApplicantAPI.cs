﻿using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IApplicantAPI
  {
    Task<ApplicantResponse> GetNation(int AllianceId);
  }
}