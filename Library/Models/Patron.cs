using System.Collections.Generic;

namespace Library.Models
{
    public class Patron
    {
        public Patron()
        {
            this.Copies = new HashSet<CopyPatron>();
        }

        public int PatronId { get; set; }
        public string Name { get; set; }

        public ICollection<CopyPatron> Copies { get;}
    }
}