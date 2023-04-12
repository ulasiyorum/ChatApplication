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

        public async Task<ServiceResponse<GetUserDto>> Login(string username, string password)
        {
            var response = new ServiceResponse<GetUserDto>();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

                if (user is null)
                    throw new Exception("User does not exist");

                else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    throw new Exception("Wrong password");



                response.Data = new GetUserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Chats = user.Chats?.Select(c => c.Id).ToList()
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> Register(AddUserDto user)
        {
            var response = new ServiceResponse<GetUserDto>();
            try
            {
                if (await UserExists(user.Username))
                    throw new Exception("User already exists");

                CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var users = await context.Users.ToListAsync();

                User us = new User
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Username = user.Username,
                };

                await context.Users.AddAsync(us);
                await context.SaveChangesAsync();

                response.Data = new GetUserDto
                {
                    Username = us.Username,
                    Chats = us.Chats?.Select(c => c.Id).ToList()
                };
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHas, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHas = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(hash);
            }
        }

        public async Task<bool> UserExists(string username)
        {
            return await context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
