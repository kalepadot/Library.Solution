using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
  public class AuthorsController : Controller
  {
    private readonly LibraryContext _db;

    public AuthorsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Authors.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Author author, int BookId)
    {
      _db.Authors.Add(author);
      if (BookId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { BookId = BookId, AuthorId = author.AuthorId } );
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Author thisAuthor = _db.Authors
        .Include(author => author.Books)
        .ThenInclude(join => join.Book)
        .FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }

    public ActionResult Edit(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(thisAuthor);
    }

    [HttpPost]
    public ActionResult Edit(Author author, int BookId)
    {
      if (BookId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { BookId = BookId, AuthorId = author.AuthorId });
      }
      _db.Entry(author).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddBook(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(thisAuthor);
    }
    
    [HttpPost]
    public ActionResult AddBook(Author author, int BookId)
    {
      if (BookId !=0)
      {
        _db.AuthorBook.Add(new AuthorBook() { BookId = BookId, AuthorId = author.AuthorId });  
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      List<AuthorBook> theseAuthorBooks = _db.AuthorBook.Where(authorBook => authorBook.AuthorId == id).ToList();
      foreach(AuthorBook dp in theseAuthorBooks)
      {
        _db.AuthorBook.Remove(dp);
      }
      _db.Authors.Remove(thisAuthor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteBook(int joinId)
    {
      var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
      _db.AuthorBook.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}