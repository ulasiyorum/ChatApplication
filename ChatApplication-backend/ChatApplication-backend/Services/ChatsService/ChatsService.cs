namespace ChatApplication_backend.Services.ChatsService
{
    public class ChatsService : IChatsService
    {
        public readonly DataContext context;

        public ChatsService(DataContext c)
        {
            context = c;
        }

        public Task<ServiceResponse<GetChatDto>> DeleteAMessage(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetChatDto>> GetAChat(int chatId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetChatDto>>> GetUsersChat(int userId)
        {
            var response = new ServiceResponse<List<GetChatDto>>();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user is null)
                    throw new Exception("User not found");

                var chats = user.Chats;

                if (chats is null)
                    throw new Exception("No chats found");

                var data = new List<GetChatDto>();

                foreach(var chat in chats)
                {
                    bool sender = chat.SenderId == userId;

                    data.Add(
                    new GetChatDto
                    {
                        IsSenderOrReceiver = sender ? Status.Sender : Status.Receiver,
                        DeletedMessages = sender ? chat.SenderDeletedMessages : chat.ReceiverDeletedMessages,
                        Messages = chat.Messages.Select(m => new GetMessageDto
                        {
                            Id = m.Id,
                            ColorHex = m.Type == MessageType.Normal ? "#808080" : m.Type == MessageType.Green ? "#81B509" :
                            m.Type == MessageType.Alert ? "#FFC535" : m.Type == MessageType.Error ? "#FF492D" : "#808080",
                            Type = m.Type.ToString(),
                            Message = m.Content,
                            SendDate = m.SendDate
                        }).ToList(),

                    }
                    );
                }


            } catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Task<ServiceResponse<GetChatDto>> SendAMessage(SendMessageDto mess)
        {
            throw new NotImplementedException();
        }
    }
}
