using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;
using PIS.Service.Common;
using PIS.Repository.Common;

namespace PIS.Service
{
    public class UlogeService : IUlogeService
    {
        private readonly IUlogeRepository _repository;

        public UlogeService(IUlogeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UlogeDomain>> GetAllUlogeAsync() => await _repository.GetAllUlogeAsync();

        public async Task<UlogeDomain> GetUlogeByIdAsync(int id) => await _repository.GetUlogeByIdAsync(id);

        public async Task<UlogeDomain> AddUlogeAsync(UlogeDomain uloge) => await _repository.AddUlogeAsync(uloge);

        public async Task UpdateUlogeAsync(UlogeDomain uloge) => await _repository.UpdateUlogeAsync(uloge);

        public async Task DeleteUlogeAsync(int id) => await _repository.DeleteUlogeAsync(id);
    }
}
