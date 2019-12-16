using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBJProject.Domain.Models;

namespace PBJProject.Client.Controllers
{
  public class LoginController : Controller
  {
    [HttpGet]
    public IActionResult Index()
    {
        return View(new Account());
    }

    [HttpPost]
    public IActionResult Index(Account user)
    {
      if(user.UserName != null)
      {
        HttpContext.Session.SetString("name",user.UserName);
        return RedirectToAction("Index","Dashboard");
      }

      return View("index", user);
    }

      public IActionResult Logout()
    {
      HttpContext.Session.SetString("name",null);

      return Redirect("/");
    }

      public IActionResult SignUp()
    {
      

      return RedirectToAction("Index","Home");
    }
  }
}