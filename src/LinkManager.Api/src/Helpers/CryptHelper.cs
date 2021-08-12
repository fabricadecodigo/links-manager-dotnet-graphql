using System;

// https://github.com/BcryptNet/bcrypt.net
namespace LinkManager.Api.src.Helpers
{
    public class CryptHelper : ICryptHelper
    {
        public string Encrypt(string value)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
            return passwordHash;
        }

        public bool IsValid(string value, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(value, hash);
        }
    }
}