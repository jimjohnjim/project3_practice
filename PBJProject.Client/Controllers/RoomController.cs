using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBJProject.Client.Models;

namespace PBJProject.Client.Controllers
{
  public class RoomController : Controller
  {
    public ActionResult Index()
    {
      if(HttpContext.Session.GetString("name") == null)
      {
        return Redirect("/");
      }

      return RedirectToAction("Chat");
    }

    public ActionResult Chat()
    {
      if(HttpContext.Session.GetString("name") == null)
      {
        return Redirect("/");
      }
      return View();
    }
  }
}