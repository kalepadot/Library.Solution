using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
  public class PatronsController : Controller
  {
    private readonly LibraryContext _db;

    public PatronsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patrons.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patron patron)
    {
      _db.Patrons.Add(patron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Patron thisPatron = _db.Patrons
        // .Include(patron => patron.CopyPatrons)                                                                         
        // .ThenInclude(join => join.CopyPatron)
        .FirstOrDefault(patron => patron.PatronId == id);
        // ViewBag.CopyId = new SelectList(_db.Copies, "CopyId", "BookId");
      return View(thisPatron);
    }

//     public ActionResult Edit(int id)
//     {
//       Author thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
//       ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
//       return View(thisAuthor);
//     }

//     [HttpPost]
//     public ActionResult Edit(Author author, int BookId)
//     {
//       if (BookId != 0)
//       {
//         _db.AuthorBook.Add(new AuthorBook() { BookId = BookId, AuthorId = author.AuthorId });
//       }
//       _db.Entry(author).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

    // public ActionResult AddCopy(int id)
    // {
    //   Patron thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
    //   ViewBag.BookId = new SelectList(_db.Books, "CopyId", "Title");
    //   return View(thisPatron);
    // }
    
    // [HttpPost]
    // public ActionResult AddBook(Patron patron, int BookId)
    // {
    //   if (BookId !=0)
    //   {
    //     _db.PatronBook.Add(new AuthorBook() { BookId = BookId, AuthorId = author.AuthorId });  
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

//     public ActionResult Delete(int id)
//     {
//       Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
//       return View(thisAuthor);
//     }
    
//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       Author thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
//       List<AuthorBook> theseAuthorBooks = _db.AuthorBook.Where(authorBook => authorBook.AuthorId == id).ToList();
//       foreach(AuthorBook dp in theseAuthorBooks)
//       {
//         _db.AuthorBook.Remove(dp);
//       }
//       _db.Authors.Remove(thisAuthor);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     [HttpPost]
//     public ActionResult DeleteBook(int joinId)
//     {
//       var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
//       _db.AuthorBook.Remove(joinEntry);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
//     public ActionResult Search(string search)
//     {
//       List<Author> model = _db.Authors.Where(author => author.Name.Contains(search)).ToList();
//       return View(model);
//     }
  }
}