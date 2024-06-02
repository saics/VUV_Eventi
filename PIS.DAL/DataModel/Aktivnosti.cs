using System;
using System.Collections.Generic;

namespace PIS.DAL.DataModel
{
    public partial class Aktivnosti
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? StatusId { get; set; }
        public int? EventId { get; set; }
        public DateTime? Datum { get; set; }
        public TimeSpan? VrijemePocetka { get; set; }
        public TimeSpan? VrijemeZavrsetka { get; set; }
        public string ImageUrl { get; set; } 

        public virtual Status Status { get; set; }
        public virtual Eventi Event { get; set; }
        public virtual ICollection<KorisniciAktivnosti> KorisniciAktivnosti { get; set; }
    }

}
