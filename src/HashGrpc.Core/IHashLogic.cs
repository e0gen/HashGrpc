namespace HashService.Application.Core
{
    public interface IHashLogic
    {
        string CalculateMD5(string rawData);
        string CalculateSHA256(string rawData);
        string CalculateSHA512(string rawData);
    }
}