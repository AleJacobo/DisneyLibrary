using System.ComponentModel.DataAnnotations;

namespace Disney.Application.AuthCommands
{
    public class LoginUser
    {
        [EmailAddress]
        public string Email { get; init; }
        public string Password { get; init; }

        public LoginUser(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
