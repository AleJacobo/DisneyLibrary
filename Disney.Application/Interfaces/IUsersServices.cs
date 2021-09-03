using Disney.Domain.DTOs;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<AuthenticationResult> LoginUser(LoginUser request);
        Task<AuthenticationResult> RegisterUser(RegisterUser request);
        Task<Result> DeleteUser(DeleteUser request);
    }
}
