using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Model
{
    public class AktivnostiDomain
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int? StatusId { get; set; }
        public int? EventId { get; set; }
        public DateTime? Datum { get; set; }
        public string VrijemePocetka { get; set; }
        public string VrijemeZavrsetka { get; set; }
        public string ImageUrl { get; set; }
    }
}

