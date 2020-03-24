using System.Collections.Generic;

namespace Library.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<AuthorBook>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }

        public ICollection<AuthorBook> Books { get;}
    }
}