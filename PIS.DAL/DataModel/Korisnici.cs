using System;
using System.Collections.Generic;

namespace PIS.DAL.DataModel
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            KorisniciAktivnosti = new HashSet<KorisniciAktivnosti>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int? UlogaId { get; set; }
        public DateTime? DatumKreiranja { get; set; }

        public virtual Uloge Uloga { get; set; }
        public virtual ICollection<KorisniciAktivnosti> KorisniciAktivnosti { get; set; }
    }
}
