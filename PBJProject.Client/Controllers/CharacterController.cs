using Microsoft.AspNetCore.Mvc;

namespace PBJProject.Client.Controllers
{
  public class CharacterController : Controller
  {
      public IActionResult Index()
    {
        return View("Character");
    }

  }
}