using PIS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Repository.Common
{
    public interface IEventiRepository
    {
        Task<IEnumerable<EventiDomain>> GetAllEventiAsync();
        Task<EventiDomain> GetEventiByIdAsync(int id);
        Task<EventiDomain> AddEventiAsync(EventiDomain eventi);
        Task UpdateEventiAsync(EventiDomain eventi);
        Task DeleteEventiAsync(int id);
    }

}

