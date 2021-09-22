using Disney.Application.AuthCommands;
using Disney.Application.Authentication;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IUsersServices
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<AuthResult> LoginUser(LoginUser request);
        Task<AuthResult> RegisterUser(RegisterUser request);
        Task<Result> DeleteUser(DeleteUser request);
    }
}
