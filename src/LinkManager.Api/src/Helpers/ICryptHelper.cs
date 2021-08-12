namespace LinkManager.Api.src.Helpers
{
    public interface ICryptHelper
    {
         string Encrypt(string value);
         bool IsValid(string value, string hash);
    }
}