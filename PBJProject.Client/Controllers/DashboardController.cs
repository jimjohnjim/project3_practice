using Microsoft.AspNetCore.Mvc;
using PBJProject.Client.Models;
using PBJProject.Storing.Repositories;

namespace PBJProject.Client.Controllers
{
	public class DashboardController : Controller
  {
     private static AccountRepository _ar = new AccountRepository();
     private static CharacterRepository _cr = new CharacterRepository();
     
    public IActionResult Index(AccountModel accountModel)
    {
       var id = _ar.GetAccountIdByUserName(accountModel.UserName);
       accountModel.MyCharacters = _cr.GetCharactersByAccountId(id);

       ViewBag.Account = accountModel;

       return View();
    }
  }
}