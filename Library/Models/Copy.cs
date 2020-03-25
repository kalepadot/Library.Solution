using System.Collections.Generic;

namespace Library.Models
{
public class Copy
  {
    public Copy()
    {
        this.Patrons = new HashSet<CopyPatron>();
    }
    public int CopyId { get; set; }
    public int BookId { get; set; } 

    public int PatronId { get; set;}
    public ICollection<CopyPatron> Patrons { get;}
  }
}