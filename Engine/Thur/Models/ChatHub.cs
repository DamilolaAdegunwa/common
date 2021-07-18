//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thur.Models
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {

        }
        //PersistentConnection
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage",message);
        }
        public async Task HelloMessage(long num)
        {
            await Clients.All.SendAsync("broadcastMessage", $"broadcast Message from Damilola Adegunwa (you sent {num})");
        }
        public override Task OnConnectedAsync()
        {
           
            Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task SendMessageToGroup(string sender, string receiver, string message)
        {
            return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
        }
        public Task SendMessageToUser(string sender, string receiver, string message)
        {
            //based on the receiver name to query the database and get the connection id

            return Clients.Client("connectionId").SendAsync("ReceiveMessage", sender, message);
        }
    }
}
