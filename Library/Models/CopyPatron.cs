using System.Collections.Generic;

namespace Library.Models
{
public class CopyPatron
  {
    public int CopyPatronId { get; set; }
    public int PatronId { get; set; }
    public string Patron { get; set; } 
    public string CheckoutDate { get; set; }
    public string DueDate { get; set; }
    public int CopyId { get; set; }
    public string Copy { get; set; }
  }
}