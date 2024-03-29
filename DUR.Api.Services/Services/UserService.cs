﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DUR.Api.Entities.Admin;
using DUR.Api.Infrastructure.Interfaces;
using DUR.Api.Repo.Database.Interfaces;
using DUR.Api.Services.Interfaces;
using DUR.Api.Services.Queries;
using DUR.Api.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DUR.Api.Services.Services;

public class UserService : DatabaseServiceBase<User>, IUserService
{
    private readonly ICryptoService _cryptoService;
    private readonly GlobalSettings _globalSettings;

    public UserService(IDatabaseUnitOfWorkFactory unitOfWorkFactory, ICryptoService cryptoService,
        IOptions<GlobalSettings> settings, IApplicationLogger logger) : base(logger)
    {
        databaseUnitOfWork = unitOfWorkFactory.Create();
        querier = new UserQueries(databaseUnitOfWork);
        _cryptoService = cryptoService;
        _globalSettings = settings.Value;
    }

    public User GetByUsername(string username)
    {
        return GetAll().Where(x => x.LoginName == username).SingleOrDefault();
    }

    public string ValidateUser(User user)
    {
        var success = GetAll().FirstOrDefault(u =>
            u.LoginName.Equals(user.LoginName, StringComparison.OrdinalIgnoreCase) &&
            _cryptoService.Validate(user.Password, u.Password));
        if (success != null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_globalSettings.SecureString);
            var token = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new(ClaimTypes.Name, user.LoginName),
                    new Claim(ClaimTypes.Role, success.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMonths(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(token));
        }

        return "";
    }

    public new User Add(User user)
    {
        user.Password = _cryptoService.CreatePasswordHash(user.Password);
        return base.Add(user);
    }
}