using System;

// https://github.com/BcryptNet/bcrypt.net
namespace LinkManager.Api.src.Helpers
{
    public static class CryptHelper
    {
        public static string Encrypt(string value)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
            return passwordHash;
        }

        public static bool IsValid(string value, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(value, hash);
        }
    }
}