using System.Threading.Tasks;
using TomLonghurst.TextValidation.Contracts;

namespace TomLonghurst.TextValidation.Validators.Async
{
    public class AsyncWrapTextValidator : IAsyncTextValidator
    {
        private readonly ITextValidator _textValidator;

        public AsyncWrapTextValidator(ITextValidator textValidator)
        {
            _textValidator = textValidator;
        }
        
        public Task<bool> IsValidAsync(string input)
        {
            return Task.FromResult(_textValidator.IsValid(input));
        }
    }
}