using System.Collections.Generic;
using System.Threading.Tasks;
using TomLonghurst.TextValidation.Contracts;

namespace TomLonghurst.TextValidation.Validators.Async
{
    public class AsyncWrapTextValidator : IAsyncTextValidator, IWrappedValidators
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

        public IEnumerable<ITextValidator> GetWrappedValidators()
        {
            yield return _textValidator;
        }
    }
}