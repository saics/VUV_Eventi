using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;
using PIS.Service.Common;
using PIS.Repository.Common;

namespace PIS.Service
{
    public class AktivnostiService : IAKtivnostiService
    {
        private readonly IAKtivnostiRepository _repository;

        public AktivnostiService(IAKtivnostiRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AktivnostiDomain>> GetAllAktivnostiAsync() => await _repository.GetAllAktivnostiAsync();

        public async Task<AktivnostiDomain> GetAktivnostiByIdAsync(int id) => await _repository.GetAktivnostiByIdAsync(id);

        public async Task<AktivnostiDomain> AddAktivnostiAsync(AktivnostiDomain aktivnosti) => await _repository.AddAktivnostiAsync(aktivnosti);

        public async Task UpdateAktivnostiAsync(AktivnostiDomain aktivnosti) => await _repository.UpdateAktivnostiAsync(aktivnosti);

        public async Task DeleteAktivnostiAsync(int id) => await _repository.DeleteAktivnostiAsync(id);
    }
}
