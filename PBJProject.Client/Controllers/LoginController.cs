using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBJProject.Client.Models;


namespace PBJProject.Client.Controllers
{
  public class LoginController : Controller
  {
     //private static AccountRepository _ar = new AccountRepository();

    [HttpGet]
    public IActionResult Index()
    {
        return View(new Login());
    }

	[HttpPost]
    public IActionResult Index(Login account)
    {
       //if(ModelState.IsValid)
       {
          //Account actualAccount = new Account();
          AccountModel accountModel = new AccountModel();
          // actualAccount = _ar.GetAccountObjectbyUserName(account.UserName);

          // accountModel.AccountId = actualAccount.AccountId;
          // accountModel.Email = actualAccount.Email;
          // accountModel.FirstName = actualAccount.FirstName;
          // accountModel.LastName = actualAccount.LastName;
          // accountModel.Password = actualAccount.Password;
          // accountModel.UserName = actualAccount.UserName;

          HttpContext.Session.SetString("name", account.UserName);
          return RedirectToAction("Index","Dashboard", accountModel);
       }

      // ViewBag.LoginError = "Invalid Username and\\or Password";
      // ViewBag.FirstNameError = "Enter a valid name";
      // return View("~/Views/Home/Index.cshtml", account);
      
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