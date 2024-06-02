using PIS.Model;
using PIS.Repository.Common;
using PIS.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Service
{
    public class EventiService : IEventiService
    {
        private readonly IEventiRepository _repository;

        public EventiService(IEventiRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EventiDomain>> GetAllEventiAsync() => await _repository.GetAllEventiAsync();
        public async Task<EventiDomain> GetEventiByIdAsync(int id) => await _repository.GetEventiByIdAsync(id);
        public async Task<EventiDomain> AddEventiAsync(EventiDomain eventi) => await _repository.AddEventiAsync(eventi);
        public async Task UpdateEventiAsync(EventiDomain eventi) => await _repository.UpdateEventiAsync(eventi);
        public async Task DeleteEventiAsync(int id) => await _repository.DeleteEventiAsync(id);
    }

}
