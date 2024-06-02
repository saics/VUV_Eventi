using System;
using System.Collections.Generic;

namespace PIS.DAL.DataModel
{
    public partial class Uloge
    {
        public Uloge()
        {
            Korisnici = new HashSet<Korisnici>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Korisnici> Korisnici { get; set; }
    }
}
