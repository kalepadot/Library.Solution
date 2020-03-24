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
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Author author, int BookId)
    {
      _db.Authors.Add(author);
      if (BookId != 0)
      {
        _db.BookAuthor.Add(new BookAuthor() { BookId = BookId, AuthorId = author.AuthorId } );
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
        _db.BookAuthor.Add(new BookAuthor() { BookId = BookId, AuthorId = author.AuthorId });
      }
      _db.Entry(author).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddBook(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Name");
      return View(thisAuthor);
    }
    
    [HttpPost]
    public ActionResult AddBook(Author author, int BookId)
    {
      if (BookId !=0)
      {
        _db.BookAuthor.Add(new BookAuthor() { BookId = BookId, AuthorId = author.AuthorId });  
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Patient thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
      return View(thisPatient);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Patient thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      List<BookPatient> theseBookPatients = _db.BookPatient.Where(bookPatient => doctorPatient.PatientId == id).ToList();
      foreach(BookPatient dp in theseBookPatients)
      {
        _db.BookPatient.Remove(dp);
      }
      _db.Patients.Remove(thisPatient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteBook(int joinId)
    {
      var joinEntry = _db.BookPatient.FirstOrDefault(entry => entry.BookPatientId == joinId);
      _db.BookPatient.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}