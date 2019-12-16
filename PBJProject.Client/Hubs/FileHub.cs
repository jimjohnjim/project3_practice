
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PBJProject.Storing.Repositories;

namespace PBJProject.Client.Hubs
{
  public class FileHub : Hub
  {
    public Task LoadFile(string filecontents)
    {
      var repo = new CharacterRepository();
      repo.Load(filecontents);
      System.Console.WriteLine(filecontents);
      return null;
    }
  }
}