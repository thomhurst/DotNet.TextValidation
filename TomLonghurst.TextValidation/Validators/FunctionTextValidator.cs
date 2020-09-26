using System;
using TomLonghurst.TextValidation.Contracts;

namespace TomLonghurst.TextValidation.Validators
{
    public class FunctionTextValidator : ITextValidator
    {
        private readonly Func<string, bool> _predicate;

        public FunctionTextValidator(Func<string, bool> predicate)
        {
            _predicate = predicate;
        }
        
        public bool IsValid(string input)
        {
            return _predicate(input);
        }
    }
}