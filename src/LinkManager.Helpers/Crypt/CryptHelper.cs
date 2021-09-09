namespace LinkManager.Helpers.Crypt
{
    using System;

    // https://github.com/BcryptNet/bcrypt.net
    public class CryptHelper : ICryptHelper
    {
        public string Encrypt(string value)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
            return passwordHash;
        }

        public bool IsValid(string value, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(value, hash);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}