using PIS.Model;
using PIS.Repository.Common;
using PIS.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIS.Service
{
    public class KorisniciService : IKorisniciService
    {
        private readonly IKorisniciRepository _repository;

        public KorisniciService(IKorisniciRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<KorisniciDomain>> GetAllKorisniciAsync()
        {
            return await _repository.GetAllKorisniciAsync();
        }

        public async Task<KorisniciDomain> GetKorisniciByIdAsync(int id)
        {
            return await _repository.GetKorisniciByIdAsync(id);
        }

        public async Task<KorisniciDomain> AddKorisniciAsync(KorisniciDomain korisnici)
        {
            return await _repository.AddKorisniciAsync(korisnici);
        }

        public async Task UpdateKorisniciAsync(KorisniciDomain korisnici)
        {
            await _repository.UpdateKorisniciAsync(korisnici);
        }

        public async Task DeleteKorisniciAsync(int id)
        {
            await _repository.DeleteKorisniciAsync(id);
        }

        public async Task<KorisniciDomain> AuthenticateAsync(string email, string lozinka)
        {
            var korisnik = await _repository.GetByEmailAsync(email);
            if (korisnik == null || korisnik.Lozinka != lozinka)
            {
                return null;
            }

            return new KorisniciDomain
            {
                Id = korisnik.Id,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email,
                UlogaId = korisnik.UlogaId,
            };
        }
    }
}
