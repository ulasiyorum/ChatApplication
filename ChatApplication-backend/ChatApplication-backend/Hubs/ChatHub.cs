using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ChatApplication_backend.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(SendMessageDto dto)
        {
            string message = JsonConvert.SerializeObject(dto);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}

