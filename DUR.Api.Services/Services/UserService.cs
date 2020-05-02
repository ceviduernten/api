using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DUR.Api.Entities.Admin;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;
using Microsoft.IdentityModel.Tokens;

namespace DUR.Api.Services.Services
{
    public class UserService : DatabaseServiceBase<User>, IUserService
    {
        public UserService(IDatabaseUnitOfWorkFactory unitOfWorkFactory)
        {
            databaseUnitOfWork = unitOfWorkFactory.Create();
            querier = new UserQueries(databaseUnitOfWork);
        }

        public string ValidateUser(User user)
        {
            var success = GetAll().FirstOrDefault(u => u.LoginName.Equals(user.LoginName, System.StringComparison.OrdinalIgnoreCase) && u.Password == user.Password);
            if (success != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("test");
                var token = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.LoginName),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.WriteToken(tokenHandler.CreateToken(token));
            }
            return "";
        }
    }
}
