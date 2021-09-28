using Disney.Domain.Common;
using System.Collections.Generic;

namespace Disney.Application.Authentication
{
    public class AuthResult : Result
    {
        public string Token { get; init; }
        public IEnumerable<string> ErrorMessages { get; init; }
    }
}
