using Disney.Application.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
