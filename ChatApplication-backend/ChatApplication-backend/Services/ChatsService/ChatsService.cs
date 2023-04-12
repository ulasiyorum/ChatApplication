using ChatApplication_backend.Models;

namespace ChatApplication_backend.Services.ChatsService
{
    public class ChatsService : IChatsService
    {
        public readonly DataContext context;

        public ChatsService(DataContext c)
        {
            context = c;
        }

        public async Task<ServiceResponse<GetChatDto>> DeleteAMessage(int id, int userId)
        {
            var response = new ServiceResponse<GetChatDto>();
            try
            {
                var message = context.Chats.Select(c => c.Messages.FirstOrDefault(m => m.Id == id));

                if (message is null)
                    throw new Exception("Message Not Found");

                var chat = await context.Chats.FirstOrDefaultAsync(c => c.Messages.FirstOrDefault(m => m.Id == id)!.Id == id);

                bool isSender = chat!.SenderId == userId;

                if (isSender)
                    chat.SenderDeletedMessages.Add(id);
                else
                    chat.ReceiverDeletedMessages.Add(id);

                var users = await context.Users.ToListAsync();

                response.Data = new GetChatDto
                {
                    IsSenderOrReceiver = isSender ? Status.Sender : Status.Receiver,
                    DeletedMessages = isSender ? chat.SenderDeletedMessages : chat.ReceiverDeletedMessages,
                    Messages = chat.Messages.Select(m => new GetMessageDto
                    {
                        Id = m.Id,
                        ColorHex = m.Type == MessageType.Normal ? "#808080" : m.Type == MessageType.Green ? "#81B509" :
                        m.Type == MessageType.Alert ? "#FFC535" : m.Type == MessageType.Error ? "#FF492D" : "#808080",
                        Type = m.Type.ToString(),
                        Message = m.Content,
                        SendDate = m.SendDate
                    }).ToList(),
                    ReceiverUsername = users.FirstOrDefault(u => u.Id == chat.ReceiverId)!.Username,
                    SenderUsername = users.FirstOrDefault(u => u.Id == chat.SenderId)!.Username,
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetChatDto>> GetAChat(int chatId, int userId)
        {
            var response = new ServiceResponse<GetChatDto>();
            try
            {
                var chat = await context.Chats.FirstOrDefaultAsync(c => c.Id == chatId);

                if (chat is null)
                    throw new Exception("Chat is not found in the database");


                var users = await context.Users.ToListAsync();
                bool isSender = chat.SenderId == userId;


                response.Data = new GetChatDto
                {
                    DeletedMessages = isSender ? chat.SenderDeletedMessages : chat.ReceiverDeletedMessages,
                    IsSenderOrReceiver = isSender ? Status.Sender : Status.Receiver,
                    ReceiverUsername = users.FirstOrDefault(u => u.Id == chat.ReceiverId)!.Username,
                    SenderUsername = users.FirstOrDefault(u => u.Id == chat.SenderId)!.Username,
                    Messages = chat.Messages.Select(m => new GetMessageDto
                    {
                        Id = m.Id,
                        ColorHex = m.Type == MessageType.Normal ? "#808080" : m.Type == MessageType.Green ? "#81B509" :
                        m.Type == MessageType.Alert ? "#FFC535" : m.Type == MessageType.Error ? "#FF492D" : "#808080",
                        Type = m.Type.ToString(),
                        Message = m.Content,
                        SendDate = m.SendDate
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
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

                var users = await context.Users.ToListAsync();

                foreach(var chat in chats)
                {
                    bool sender = chat.SenderId == userId;

                    string senderName = users.FirstOrDefault(u => u.Id == chat.SenderId)!.Username;
                    string receiverName = users.FirstOrDefault(u => u.Id == chat.ReceiverId)!.Username;
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
                        ReceiverUsername = receiverName,
                        SenderUsername = senderName,
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

        public async Task<ServiceResponse<GetChatDto>> SendAMessage(SendMessageDto mess)
        {
            var response = new ServiceResponse<GetChatDto>();
            try
            {

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
