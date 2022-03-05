using System;
using System.Security.Cryptography;
using System.Text;
using DUR.Api.Services.Interfaces;

namespace DUR.Api.Services.Services;

public class CryptoService : ICryptoService
{
    public string CreatePasswordHash(string pwd)
    {
        return CreatePasswordHash(pwd, CreateSalt());
    }

    public string CreatePasswordHash(string pwd, string salt)
    {
        var saltAndPwd = string.Concat(pwd, salt);
        var hashedPwd = GetHashString(saltAndPwd);
        var saltPosition = 5;
        hashedPwd = hashedPwd.Insert(saltPosition, salt);
        return hashedPwd;
    }

    public bool Validate(string password, string passwordHash)
    {
        var saltPosition = 5;
        var saltSize = 10;
        var salt = passwordHash.Substring(saltPosition, saltSize);
        var hashedPassword = CreatePasswordHash(password, salt);
        return hashedPassword == passwordHash;
    }

    private string CreateSalt()
    {
        var rng = new RNGCryptoServiceProvider();
        var buff = new byte[20];
        rng.GetBytes(buff);
        var saltSize = 10;
        var salt = Convert.ToBase64String(buff);
        if (salt.Length > saltSize)
        {
            salt = salt.Substring(0, saltSize);
            return salt.ToUpper();
        }

        var saltChar = '^';
        salt = salt.PadRight(saltSize, saltChar);
        return salt.ToUpper();
    }

    private string GetHashString(string password)
    {
        var sb = new StringBuilder();
        foreach (var b in GetHash(password))
            sb.Append(b.ToString("X2"));
        return sb.ToString();
    }

    private byte[] GetHash(string password)
    {
        SHA384 sha = new SHA384CryptoServiceProvider();
        return sha.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}