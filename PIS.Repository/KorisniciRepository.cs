using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;

namespace PIS.Repository
{
    public class KorisniciRepository : IKorisniciRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public KorisniciRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KorisniciDomain>> GetAllKorisniciAsync()
        {
            var entities = await _context.Korisnici.ToListAsync();
            return _mapper.Map<IEnumerable<KorisniciDomain>>(entities);
        }

        public async Task<KorisniciDomain> GetKorisniciByIdAsync(int id)
        {
            var entity = await _context.Korisnici.FindAsync(id);
            return _mapper.Map<KorisniciDomain>(entity);
        }

        public async Task<KorisniciDomain> AddKorisniciAsync(KorisniciDomain korisnici)
        {
            var entity = _mapper.Map<Korisnici>(korisnici);
            _context.Korisnici.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<KorisniciDomain>(entity);
        }

        public async Task UpdateKorisniciAsync(KorisniciDomain korisnici)
        {
            var entity = await _context.Korisnici.FindAsync(korisnici.Id);
            if (entity != null)
            {
                _mapper.Map(korisnici, entity);
                _context.Korisnici.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteKorisniciAsync(int id)
        {
            var entity = await _context.Korisnici.FindAsync(id);
            if (entity != null)
            {
                _context.Korisnici.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Korisnici> GetByEmailAsync(string email)
        {
            return await _context.Korisnici.SingleOrDefaultAsync(k => k.Email == email);
        }
    }
}
