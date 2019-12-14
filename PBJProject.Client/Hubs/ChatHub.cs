using Microsoft.AspNetCore.SignalR;
using PBJProject.Client.Models;
using System;
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
      var caller = Users[Context.ConnectionId];
      await Clients.Group(caller.group).SendAsync("ReceiveMessage", caller.name, message);
    }

    public async Task JoinRoom(string userName, string roomName)
    {
      string cId = Context.ConnectionId;
      Users.GetOrAdd(cId, new User(){name = userName, group = roomName});
      numUsers.AddOrUpdate(roomName,1,(key, oldValue) => oldValue + 1);
      foreach(var item in Users)
      {
        System.Console.WriteLine(item.Value.name + " " + item.Key + " " + item.Value.group + " " + numUsers[roomName]);
      }
      
      await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
      await Clients.Group(roomName).SendAsync("UserJoined",userName,numUsers[roomName]);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
      var caller = Users[Context.ConnectionId];
      numUsers.AddOrUpdate(caller.group,1,(key, oldValue) => oldValue - 1);
      await Clients.Group(caller.group).SendAsync("UserLeft",caller.name,numUsers[caller.group]);
      Users.TryRemove(Context.ConnectionId, out caller);
    }

  }
}