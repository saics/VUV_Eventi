using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;
using PIS.Service.Common;
using PIS.Repository.Common;

namespace PIS.Service
{
    public class KorisniciAktivnostiService : IKorisniciAktivnostiService
    {
        private readonly IKorisniciAktivnostiRepository _repository;

        public KorisniciAktivnostiService(IKorisniciAktivnostiRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetAllKorisniciAktivnostiAsync() => await _repository.GetAllKorisniciAktivnostiAsync();

        public async Task<KorisniciAktivnostiDomain> GetKorisniciAktivnostiByIdAsync(int id) => await _repository.GetKorisniciAktivnostiByIdAsync(id);

        public async Task<KorisniciAktivnostiDomain> AddKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnosti) => await _repository.AddKorisniciAktivnostiAsync(korisniciAktivnosti);

        public async Task UpdateKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnosti) => await _repository.UpdateKorisniciAktivnostiAsync(korisniciAktivnosti);

        public async Task DeleteKorisniciAktivnostiAsync(int id) => await _repository.DeleteKorisniciAktivnostiAsync(id);
    }
}
