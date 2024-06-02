using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PIS.DAL.DataModel;
using PIS.Model;
using PIS.Repository.Common;

namespace PIS.Repository
{
    public class KorisniciAktivnostiRepository : IKorisniciAktivnostiRepository
    {
        private readonly PIS_DbContext2 _context;
        private readonly IMapper _mapper;

        public KorisniciAktivnostiRepository(PIS_DbContext2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KorisniciAktivnostiDomain>> GetAllKorisniciAktivnostiAsync()
        {
            var korisniciAktivnosti = await _context.KorisniciAktivnosti.ToListAsync();
            return _mapper.Map<IEnumerable<KorisniciAktivnostiDomain>>(korisniciAktivnosti);
        }

        public async Task<KorisniciAktivnostiDomain> GetKorisniciAktivnostiByIdAsync(int id)
        {
            var korisniciAktivnosti = await _context.KorisniciAktivnosti.FindAsync(id);
            return _mapper.Map<KorisniciAktivnostiDomain>(korisniciAktivnosti);
        }

        public async Task<KorisniciAktivnostiDomain> AddKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnosti)
        {
            var entity = _mapper.Map<KorisniciAktivnosti>(korisniciAktivnosti);

            // Check if the QR code already exists for the user-event combination
            var existingQrCode = await _context.KorisniciAktivnosti
                .FirstOrDefaultAsync(ka => ka.KorisnikId == korisniciAktivnosti.KorisnikId && ka.EventId == korisniciAktivnosti.EventId);

            if (existingQrCode != null)
            {
                entity.QrKod = existingQrCode.QrKod;  // Reuse existing QR code
            }
            else
            {
                // Generate a new QR code for the user-event combination
                entity.QrKod = GenerateQrCode(korisniciAktivnosti.KorisnikId, korisniciAktivnosti.EventId);
            }

            _context.KorisniciAktivnosti.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<KorisniciAktivnostiDomain>(entity);
        }

        public async Task UpdateKorisniciAktivnostiAsync(KorisniciAktivnostiDomain korisniciAktivnosti)
        {
            var entity = await _context.KorisniciAktivnosti.FindAsync(korisniciAktivnosti.Id);
            if (entity != null)
            {
                _mapper.Map(korisniciAktivnosti, entity);
                _context.KorisniciAktivnosti.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteKorisniciAktivnostiAsync(int id)
        {
            var entity = await _context.KorisniciAktivnosti.FindAsync(id);
            if (entity != null)
            {
                _context.KorisniciAktivnosti.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Example method to generate QR code
        private byte[] GenerateQrCode(int? korisnikId, int? eventId)
        {
            // Use a QR code library to generate the QR code as a byte array
            var qrData = $"{korisnikId}_{eventId}";
            // QR code generation logic here
            return new byte[0];  // Replace with actual QR code byte array
        }
    }
}
