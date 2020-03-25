using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace Library.Controllers
{
  [Authorize]
  public class PatronsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PatronsController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userPatrons = _db.Patrons.Where(entry => entry.User.Id == currentUser.Id);
      return View(userPatrons);
    }

    public ActionResult Create()
    {
      ViewBag.CopyId = new SelectList(_db.Copies, "CopyId", "BookId");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Patron patron, int CopyId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      patron.User = currentUser;
      _db.Patrons.Add(patron);
      if (CopyId != 0)
      {
        _db.CopyPatrons.Add(new CopyPatron() { CopyId = CopyId, PatronId = patron.PatronId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Patron thisPatron = _db.Patrons
        // .Include(patron => patron.CopyPatrons)                                                                         
        // .ThenInclude(join => join.CopyPatron)
        .FirstOrDefault(patron => patron.PatronId == id);

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