using System.Threading.Tasks;

namespace TomLonghurst.TextValidation.Contracts
{
    public interface IAsyncTextValidator
    {
        Task<bool> IsValidAsync(string input);
    }
}