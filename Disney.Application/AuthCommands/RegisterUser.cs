using System.ComponentModel.DataAnnotations;

namespace Disney.Application.AuthCommands
{
    public class RegisterUser
    {
        [EmailAddress]
        public string Email { get; init; }

        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
