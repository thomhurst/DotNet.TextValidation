using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Examples.DependencyInjection.Custom.RegisterableInterfaces;
using TomLonghurst.TextValidation.Extensions;
using TomLonghurst.TextValidation.Predefined;

namespace TomLonghurst.TextValidation.Examples.DependencyInjection.Custom
{
    public class LettersOnlyValidator : ILettersOnlyValidator
    {
        private readonly ITextValidator _innerValidator = PredefinedTextValidation.IsLettersOnly.GetValidator();

        public bool IsValid(string input)
        {
            return _innerValidator.IsValid(input);
        }
    }
}