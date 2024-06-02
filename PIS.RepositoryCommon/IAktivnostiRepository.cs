using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;

namespace PIS.Repository.Common
{
    public interface IAKtivnostiRepository
    {
        Task<IEnumerable<AktivnostiDomain>> GetAllAktivnostiAsync();
        Task<AktivnostiDomain> GetAktivnostiByIdAsync(int id);
        Task<AktivnostiDomain> AddAktivnostiAsync(AktivnostiDomain aktivnosti);
        Task UpdateAktivnostiAsync(AktivnostiDomain aktivnosti);
        Task DeleteAktivnostiAsync(int id);
    }
}
