using System;
using System.Threading.Tasks;
using TomLonghurst.TextValidation.Contracts;

namespace TomLonghurst.TextValidation.Validators.Async
{
    public class AsyncFunctionTextValidator : IAsyncTextValidator
    {
        private readonly Func<string, Task<bool>> _predicate;

        public AsyncFunctionTextValidator(Func<string, Task<bool>> predicate)
        {
            _predicate = predicate;
        }
        
        public Task<bool> IsValidAsync(string input)
        {
            return _predicate(input);
        }
    }
}