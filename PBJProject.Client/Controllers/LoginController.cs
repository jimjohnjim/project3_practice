using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBJProject.Client.Models;
using PBJProject.Storing.Repositories;

namespace PBJProject.Client.Controllers
{
  public class LoginController : Controller
  {
     private static AccountRepository _ar = new AccountRepository();

    [HttpGet]
    public IActionResult Index()
    {
        return View(new Login());
    }

    [HttpPost]
    public IActionResult Index(Login account)
    {
       if(ModelState.IsValid)
       {
          
            HttpContext.Session.SetString("name", account.UserName);
            return RedirectToAction("Index","Dashboard", account);
       }

      ViewBag.LoginError = "Invalid Username and\\or Password";
      ViewBag.FirstNameError = "Enter a valid name";
      return View("~/Views/Home/Index.cshtml", account);
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