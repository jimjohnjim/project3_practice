using Microsoft.AspNetCore.Mvc;

namespace PBJProject.Client.Controllers
{
  public class LoginController : Controller
  {
    public IActionResult Index()
    {
        return View();
    }

  }
}