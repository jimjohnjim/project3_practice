using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PBJProject.Domain.Models;

namespace PBJProject.WebAPI.Client.Controllers
{
  [Produces("application/json")]
  [Route("/api/[controller]")]
  [ApiController]
  public class DiceController : ControllerBase
  {
    private ILogger _logger;
    private ChatParser parser = new ChatParser();

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return await Task.Run(() => { return Ok(); });
    }

    [HttpGet("{nds}")]
    public async Task<IActionResult> Get(string nds)
    {
      var list = parser.GetRoll(nds);
      Dice dice = new Dice(list[0], list[1]);
      dice.Roll();
      return await Task.FromResult(Ok(dice.Values));
    }

   //  [HttpPost]
   //  public async Task<IActionResult> Post(Pokemon poke)
   //  {
   //    if (ModelState.IsValid)
   //    {
   //      _db.Pokemon.Add(poke);
   //      _db.SaveChanges();

   //      return await Task.FromResult(Ok(poke));
   //    }

   //    return await Task.FromResult(NotFound(poke));
   //  }
  }
}