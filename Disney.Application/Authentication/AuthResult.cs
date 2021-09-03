using Disney.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Authentication
{
    public class AuthResult : Result
    {
        public string Token { get; init; }
        public IEnumerable<string> ErrorMessages { get; init; }
    }   
}
