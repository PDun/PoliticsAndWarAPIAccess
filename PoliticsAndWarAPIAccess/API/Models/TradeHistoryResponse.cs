using System.Collections.Generic;

namespace PoliticsAndWarAPIAccess.API.Models
{
  public class TradeHistoryResponse
  {
    public bool success { get; set; }
    public List<TradeHistory> trades { get; set; }
  }
}
