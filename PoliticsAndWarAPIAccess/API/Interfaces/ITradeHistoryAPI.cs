﻿using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface ITradeHistoryAPI
  {
    Task<TradeHistory> GetTradeHistory(string apiKey, Resources[] resources, int records = 10000);
  }
}