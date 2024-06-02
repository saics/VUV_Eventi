using System;
using System.Collections.Generic;

namespace PIS.DAL.DataModel
{
    public partial class Eventi
    {
        public Eventi()
        {
            Aktivnosti = new HashSet<Aktivnosti>();
            KorisniciAktivnosti = new HashSet<KorisniciAktivnosti>();  // Ensure this collection is added
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? StatusId { get; set; }
        public string Lokacija { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public TimeSpan? VrijemePocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }
        public TimeSpan? VrijemeZavrsetka { get; set; }
        public string ImageUrl { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Aktivnosti> Aktivnosti { get; set; }
        public virtual ICollection<KorisniciAktivnosti> KorisniciAktivnosti { get; set; }  // Ensure this collection is added
    }
}
