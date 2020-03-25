using System.Collections.Generic;

namespace Library.Models
{
    public class Patron
    {
        public Patron()
        {
            this.CopyPatrons = new HashSet<CopyPatron>();
        }

        public int PatronId { get; set; }
        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CopyPatron> CopyPatrons { get;}
    }
}