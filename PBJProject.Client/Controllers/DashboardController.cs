using Microsoft.AspNetCore.Mvc;
using PBJProject.Client.Models;

namespace PBJProject.Client.Controllers
{
	public class DashboardController : Controller
  {
    //private static readonly HttpClient client = new HttpClient();
     //private static AccountRepository _ar = new AccountRepository();
     //private static CharacterRepository _cr = new CharacterRepository();
     
    public IActionResult Index(AccountModel accountModel)
    {
       //var id = _ar.GetAccountIdByUserName(accountModel.UserName);
       //accountModel.MyCharacters = _cr.GetCharactersByAccountId(id);

       //iewBag.Account = accountModel;

       return View();
    }
  }
}