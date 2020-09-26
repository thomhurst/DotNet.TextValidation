using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Extensions;

namespace TomLonghurst.TextValidation.Validators.Async
{
    public class AsyncMultipleTextValidators : IAsyncTextValidator, IAsyncWrappedValidator
    {
        private readonly IEnumerable<IAsyncTextValidator> _textValidators;

        public AsyncMultipleTextValidators(IEnumerable<IAsyncTextValidator> textValidators)
        {
            _textValidators = textValidators.UnwrapAllAsync();
        }
        
        public AsyncMultipleTextValidators(params IAsyncTextValidator[] textValidators)
        {
            _textValidators = textValidators.UnwrapAllAsync();
        }

        public AsyncMultipleTextValidators(ITextValidator textValidator, IAsyncTextValidator asyncTextValidator)
        {
            _textValidators = asyncTextValidator.WrapAsync(textValidator).UnwrapAllAsync();
        }
        
        public AsyncMultipleTextValidators(IAsyncTextValidator asyncTextValidator, ITextValidator textValidator)
        {
            _textValidators = asyncTextValidator.WrapAsync(textValidator).UnwrapAllAsync();
        }
        
        public Task<bool> IsValidAsync(string input)
        {
            return _textValidators.Select(validator => validator.IsValidAsync(input)).AllAsync();
        }

        public IEnumerable<IAsyncTextValidator> GetWrappedAsyncValidators()
        {
            return _textValidators;
        }
    }
}