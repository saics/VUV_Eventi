using System.Collections.Generic;
using System.Threading.Tasks;
using PIS.Model;

namespace PIS.Service.Common
{
    public interface IAKtivnostiService
    {
        Task<IEnumerable<AktivnostiDomain>> GetAllAktivnostiAsync();
        Task<AktivnostiDomain> GetAktivnostiByIdAsync(int id);
        Task<AktivnostiDomain> AddAktivnostiAsync(AktivnostiDomain aktivnosti);
        Task UpdateAktivnostiAsync(AktivnostiDomain aktivnosti);
        Task DeleteAktivnostiAsync(int id);
    }
}
