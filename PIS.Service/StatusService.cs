using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;
using PIS.Service.Common;
using PIS.Repository.Common;

namespace PIS.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StatusDomain>> GetAllStatusAsync() => await _repository.GetAllStatusAsync();

        public async Task<StatusDomain> GetStatusByIdAsync(int id) => await _repository.GetStatusByIdAsync(id);

        public async Task<StatusDomain> AddStatusAsync(StatusDomain status) => await _repository.AddStatusAsync(status);

        public async Task UpdateStatusAsync(StatusDomain status) => await _repository.UpdateStatusAsync(status);

        public async Task DeleteStatusAsync(int id) => await _repository.DeleteStatusAsync(id);
    }
}
