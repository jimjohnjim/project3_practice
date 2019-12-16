using Microsoft.AspNetCore.Mvc;

namespace PBJProject.Client.Controllers
{
  public class CharacterController : Controller
  {
      public IActionResult Index()
    {
        return View("Character");
    }
      public IActionResult ViewCharacter()
    {
        return View("_ViewCharacter");
    }

     public IActionResult NewCharacter()
    {
      
        return View("_NewCharacter");
    }
  }
}