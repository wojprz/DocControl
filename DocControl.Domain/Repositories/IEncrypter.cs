namespace DocControl.Domain.Repositories
{
    public interface IEncrypter
    {
        string GetSalt(string values);
        string GetHash(string value, string salt);
    }
}
