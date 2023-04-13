global using Microsoft.AspNetCore.Mvc;
global using ChatApplication_backend.Hubs;
using ChatApplication_backend.Services.ChatsService;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChatsController : ControllerBase
    {
        public readonly IChatsService service;
        public readonly IHubContext<ChatHub> hubContext;
        public ChatsController(IChatsService serv,IHubContext<ChatHub> chatHub)
        {
            service = serv;
            hubContext = chatHub;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetChatDto>>>> GetChats(int id)
        {
            return Ok(await service.GetUsersChat(id));
        }

        [HttpGet("{userId}/{chatId}")]
        public async Task<ActionResult<ServiceResponse<GetChatDto>>> GetChat(int chatId, int userId)
        {
            return Ok(await service.GetAChat(chatId, userId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetChatDto>>> Send(SendMessageDto dto)
        {
            try
            {
                var resp = await service.SendAMessage(dto);

                await hubContext.Clients.All.SendAsync("SendMessage");

                return Ok(resp);
            }
            catch
            {
                return BadRequest();
            }


        }

        [HttpDelete("{userId}/{id}")]
        public async Task<ActionResult<ServiceResponse<GetChatDto>>> DeleteMessage(int id, int userId)
        {
            return Ok(await service.DeleteAMessage(id, userId));
        }
    }
}
