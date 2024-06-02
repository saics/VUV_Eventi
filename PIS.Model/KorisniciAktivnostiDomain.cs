using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Model
{
    public class KorisniciAktivnostiDomain
    {
        public int Id { get; set; }
        public int? KorisnikId { get; set; }
        public int? AktivnostId { get; set; }
        public int? EventId { get; set; }
        public byte[] QrKod { get; set; }

        public KorisniciDomain Korisnik { get; set; }
        public AktivnostiDomain Aktivnost { get; set; }
        public EventiDomain Event { get; set; }
    }
}

