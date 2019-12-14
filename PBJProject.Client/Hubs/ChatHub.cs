using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using PBJProject.Client.Models;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace PBJProject.Client.Hubs
{
  public class ChatHub : Hub
  {
    private static readonly ConcurrentDictionary<string, int> numUsers = new ConcurrentDictionary<string, int>();

    private static readonly ConcurrentDictionary<string, User> Users = new ConcurrentDictionary<string, User>();

    public async Task SendMessage(string user, string message)
    {
      await Clients.Group(Users[user].group).SendAsync("ReceiveMessage", user, message);
    }

    public Task JoinRoom(string userName, string roomName)
    {
      string cId = Context.ConnectionId;
      var user = Users.GetOrAdd(userName, new User(){connectionId = cId, group = roomName});
      numUsers.AddOrUpdate(roomName,1,(key, oldValue) => oldValue + 1);
      foreach(var item in Users)
      {
        System.Console.WriteLine(userName + " " + item.Value.connectionId + " " + item.Value.group + " " + numUsers[roomName]);
      }
      
      Groups.AddToGroupAsync(Context.ConnectionId, roomName);
      return Clients.Group(roomName).SendAsync("UserJoined",userName,numUsers[roomName]);
    }

    public Task LeaveRoom(string roomName)
    {
      Clients.Group(roomName).SendAsync("ReceiveMessage",Context.ConnectionId,"Has left the chat.");
      return Groups.RemoveFromGroupAsync(Context.UserIdentifier, roomName);
    }
  }
}