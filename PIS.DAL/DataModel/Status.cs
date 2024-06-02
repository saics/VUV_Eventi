using System;
using System.Collections.Generic;

namespace PIS.DAL.DataModel
{
    public partial class Status
    {
        public Status()
        {
            Aktivnosti = new HashSet<Aktivnosti>();
            Eventi = new HashSet<Eventi>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Aktivnosti> Aktivnosti { get; set; }
        public virtual ICollection<Eventi> Eventi { get; set; }
    }
}
