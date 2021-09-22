using Disney.Application.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Disney.Application.AuthCommands
{
    public class DeleteUser : LoggedRequest
    {
        [EmailAddress]
        public string Email { get; init; }
        public DeleteUser(string email)
        {
            Email = email;
        }
    }
}
