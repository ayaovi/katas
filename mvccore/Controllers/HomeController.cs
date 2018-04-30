using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mvccore.Models;
using mvccore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace mvccore.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      using (var context = new LibraryContext())
      {
        var books = context.Book.Include(p => p.Publisher).ToList();
        return View(books);
      }
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
