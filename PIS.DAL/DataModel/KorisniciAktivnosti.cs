using System;
using System.Collections.Generic;

namespace PIS.DAL.DataModel
{
    public partial class KorisniciAktivnosti
    {
        public int Id { get; set; }
        public int? KorisnikId { get; set; }
        public int? AktivnostId { get; set; }
        public int? EventId { get; set; }  // Ensure this property is added
        public byte[] QrKod { get; set; }  // Ensure this property is added

        public virtual Korisnici Korisnik { get; set; }
        public virtual Aktivnosti Aktivnost { get; set; }
        public virtual Eventi Event { get; set; }  // Ensure this property is added
    }
}
