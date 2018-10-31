using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IAllianceAPI
  {
    Task<Alliance> GetAlliance(int id);
  }
}