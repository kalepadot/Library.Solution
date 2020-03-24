namespace Library.Models
{
  public class BookCopy
  {
    public int BookCopyId { get; set; }
    public int CopyId { get; set; }
    public int BookId { get; set; }
    public Copy Copy { get; set; }
    public Book Book { get; set; }
  }
}