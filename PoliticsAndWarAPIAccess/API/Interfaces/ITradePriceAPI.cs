﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface ITradePriceAPI
  {
    Task<TradePrice> GetTradePrice(Resources resource, string apiKey, Expression<Func<TradePrice, bool>> expression = null, bool UseCache = true);
  }
}