using PBJProject.Client.Hubs;
using Xunit;
using Moq;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Dynamic;
using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using PBJProject.Client.Models;

namespace PBJProject.Testing.Specs.PBJProject.Client.Hubs
{
  public class ChatHubTest
  {
    public async Task Test_SendMessage()
    {
      Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
      Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();
      var hub = new ChatHub();
      //var all = new Mock<IClientContract>();
      hub.Clients = mockClients.Object;

      // all.Setup(m => m.broadcastMessage(It.IsAny<string>(), 
      //           It.IsAny<string>())).Verifiable();
      mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);
      await hub.SendMessage("TestUser", "TestMessage");
      mockClients.VerifyAll();
    }

    [Fact]
    public async Task Test_OnConnectedAsync()
    {
      Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
      Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();
      var hub = new ChatHub();
      hub.Clients = mockClients.Object;

      await hub.OnConnectedAsync();
      mockClients.VerifyAll();
    }

  }
}