using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface ITradeHistoryAPI
  {
    Task<TradeHistoryResponse> GetTradeHistory(string apiKey, Resources[] resources, int records = 10000, Expression<Func<TradeHistory, bool>> expression = null, bool UseCache = true);
  }
}