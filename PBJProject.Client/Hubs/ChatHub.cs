using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PBJProject.Client.Hubs
{
  public class ChatHub : Hub
  {
    private int users = 0;

    public async Task SendMessage(string user, string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public Task JoinRoom(string roomName)
    {
      return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
    }

    public Task LeaveRoom(string roomName)
    {
      Clients.Group(roomName).SendAsync("ReceiveMessage",Context.User,"Has left the chat.");
      return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
    }

    public async override Task OnConnectedAsync()
    {
      users++;
      await SendMessage(Context.UserIdentifier, "Has Joined");
    }

    public async override Task OnDisconnectedAsync(System.Exception exception)
    {
      users--;
      await SendMessage(Context.UserIdentifier, "Has Left");
    }
  }
}