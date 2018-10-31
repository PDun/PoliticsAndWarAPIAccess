using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IAlliancesAPI
  {
    Task<AlliancesResponse> GetAlliances();
  }
}