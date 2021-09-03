using AutoMapper;
using Disney.Application.AuthCommands;
using Disney.Application.Authentication;
using Disney.Application.Interfaces;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using Disney.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class UsersServices : IUsersServices
    {
        #region Objects and Constructor

        private readonly UserManager<User> userManager;
        private readonly JWTSettings jwtSettings;
        private readonly IConfiguration Iconfiguration;
        private readonly IUserStore<User> userStore;
        private readonly IMapper mapper;
        private readonly IBaseRepository<User> baseRepository;
        private readonly UsersRepository usersRepository;

        public UsersServices(UserManager<User> userManager,
                           JWTSettings jwtSettings,
                           IConfiguration Iconfiguration,
                           IUserStore<User> userStore,
                           IMapper mapper,
                           IBaseRepository<User> baseRepository,
                           UsersRepository usersRepository)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.Iconfiguration = Iconfiguration;
            this.userStore = userStore;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.usersRepository = usersRepository;
        }
        #endregion

        #region Token Generator
        private AuthResult GenerateAuthResult(IdentityUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString("d")),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id),
                    new Claim("createdAt", DateTimeHelper.GetSystemDate().ToString()),
                }),

                Expires = DateTimeHelper.GetSystemDate()
                .AddHours(Convert.ToInt32(Iconfiguration.GetSection("JwtSettings:ValidHours").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResult
            {
                HasErrors = false,
                Token = tokenHandler.WriteToken(token)
            };
        }

        private AuthResult ValidateUserException(string validationMessage)
        {
            return new AuthResult
            {
                ErrorMessages = new[] { validationMessage }
            };
        }
        #endregion

        #region Helper
        public static class DateTimeHelper
        {
            private const string TIMEZONE_USAGE = "Argentina Standard Time";

            public static DateTime GetSystemDate()
                => TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.UtcNow,
                    TimeZoneInfo.FindSystemTimeZoneById(TIMEZONE_USAGE)
                    );
        }
        #endregion

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var response = await baseRepository.GetAll();
            var result = mapper.Map<IEnumerable<UserDTO>>(response);

            return result;
        }
        public async Task<AuthResult> RegisterUser(RegisterUser request)
        {
            var exsistingUser = await userManager.FindByEmailAsync(request.Email);
            if (exsistingUser != null)
            {
                return ValidateUserException(AuthValidationResponses.UserAlreadyExists);
            }

            var newUser = mapper.Map<User>(request);

            var registeruser = await userManager.CreateAsync(newUser, request.Password);

            if (!registeruser.Succeeded)
                return new AuthResult { ErrorMessages = registeruser.Errors.Select(x => x.Description) };

            return GenerateAuthResult(newUser);
        }
        public async Task<AuthResult> LoginUser(LoginUser request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user==null)
            {
                return ValidateUserException(AuthValidationResponses.UserDoesNotExist);
            }

            var validUserPass = await userManager.CheckPasswordAsync(user, request.Password);
            if (validUserPass)
            {
                return ValidateUserException(AuthValidationResponses.UserOrPasswordAreIncorrect);
            }

            return GenerateAuthResult(user);
        }
        public async Task<Result> DeleteUser(DeleteUser request)
        {
            var requester = await userStore.FindByIdAsync(request.GetUser(), new CancellationToken());

            if (requester == null)
                return new Result().NotFound();

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return ValidateUserException(AuthValidationResponses.UserDoesNotExist);

            var entity = mapper.Map<User>(user);

            await baseRepository.Update(entity);
            return new Result().Success($"Se ha borrado al usuario del sistema");
        }

    }
}
