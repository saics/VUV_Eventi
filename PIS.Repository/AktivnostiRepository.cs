using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;

namespace PIS.Repository
{
    public class AktivnostiRepository : IAKtivnostiRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public AktivnostiRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AktivnostiDomain>> GetAllAktivnostiAsync()
        {
            var aktivnosti = await _context.Aktivnosti.ToListAsync();
            return _mapper.Map<IEnumerable<AktivnostiDomain>>(aktivnosti);
        }

        public async Task<AktivnostiDomain> GetAktivnostiByIdAsync(int id)
        {
            var aktivnosti = await _context.Aktivnosti.FindAsync(id);
            return _mapper.Map<AktivnostiDomain>(aktivnosti);
        }

        public async Task<AktivnostiDomain> AddAktivnostiAsync(AktivnostiDomain aktivnosti)
        {
            var entity = _mapper.Map<Aktivnosti>(aktivnosti);
            _context.Aktivnosti.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AktivnostiDomain>(entity);
        }

        public async Task UpdateAktivnostiAsync(AktivnostiDomain aktivnosti)
        {
            var entity = await _context.Aktivnosti.FindAsync(aktivnosti.Id);
            if (entity != null)
            {
                _mapper.Map(aktivnosti, entity);
                _context.Aktivnosti.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAktivnostiAsync(int id)
        {
            var entity = await _context.Aktivnosti.FindAsync(id);
            if (entity != null)
            {
                _context.Aktivnosti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
