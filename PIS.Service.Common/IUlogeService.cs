using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;

namespace PIS.Service.Common
{
    public interface IUlogeService
    {
        Task<IEnumerable<UlogeDomain>> GetAllUlogeAsync();
        Task<UlogeDomain> GetUlogeByIdAsync(int id);
        Task<UlogeDomain> AddUlogeAsync(UlogeDomain uloge);
        Task UpdateUlogeAsync(UlogeDomain uloge);
        Task DeleteUlogeAsync(int id);
    }
}
