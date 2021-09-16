namespace LinkManager.Helpers.Crypt
{
    public interface ICryptHelper
    {
        string Encrypt(string value);
        bool IsValid(string value, string hash);
    }
}