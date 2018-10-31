﻿using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface ITradePriceAPI
  {
    Task<TradePrice> GetAlliance(Resources resource);
  }
}