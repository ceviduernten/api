namespace DUR.Api.Services.Interfaces;

public interface ICryptoService
{
    string CreatePasswordHash(string pwd);

    string CreatePasswordHash(string pwd, string salt);

    bool Validate(string password, string passwordHash);
}