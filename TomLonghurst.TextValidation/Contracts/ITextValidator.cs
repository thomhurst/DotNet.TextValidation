namespace TomLonghurst.TextValidation.Contracts
{
    public interface ITextValidator
    {
        bool IsValid(string input);
    }
}