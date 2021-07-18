using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Publico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publico.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task sendMessage(Message message)
        {
            var x = Context?.User;
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
