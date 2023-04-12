global using ChatApplication_backend.Data;
global using ChatApplication_backend.Dtos;
global using ChatApplication_backend.Models;

namespace ChatApplication_backend.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public readonly DataContext context;
        public AuthService(DataContext c)
        {
            context = c;
        }

        public Task<ServiceResponse<GetUserDto>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetUserDto>> Register(User user, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(string username)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Username == username) is not null;
        }
    }
}
