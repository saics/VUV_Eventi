using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;

namespace PIS.Service.Common
{
    public interface IKorisniciService
    {
        Task<IEnumerable<KorisniciDomain>> GetAllKorisniciAsync();
        Task<KorisniciDomain> GetKorisniciByIdAsync(int id);
        Task<KorisniciDomain> AddKorisniciAsync(KorisniciDomain korisnici);
        Task UpdateKorisniciAsync(KorisniciDomain korisnici);
        Task DeleteKorisniciAsync(int id);
        Task<KorisniciDomain> AuthenticateAsync(string email, string lozinka);
    }
}
