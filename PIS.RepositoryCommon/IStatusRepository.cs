using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;

namespace PIS.Repository.Common
{
    public interface IStatusRepository
    {
        Task<IEnumerable<StatusDomain>> GetAllStatusAsync();
        Task<StatusDomain> GetStatusByIdAsync(int id);
        Task<StatusDomain> AddStatusAsync(StatusDomain status);
        Task UpdateStatusAsync(StatusDomain status);
        Task DeleteStatusAsync(int id);
    }
}
