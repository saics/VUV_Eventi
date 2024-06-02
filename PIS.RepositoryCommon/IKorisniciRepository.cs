using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.DAL.DataModel;
using PIS.Model;

namespace PIS.Repository.Common
{
    public interface IKorisniciRepository
    {
        Task<IEnumerable<KorisniciDomain>> GetAllKorisniciAsync();
        Task<KorisniciDomain> GetKorisniciByIdAsync(int id);
        Task<KorisniciDomain> AddKorisniciAsync(KorisniciDomain korisnici);
        Task UpdateKorisniciAsync(KorisniciDomain korisnici);
        Task DeleteKorisniciAsync(int id);
        Task<Korisnici> GetByEmailAsync(string email);
    }
}
