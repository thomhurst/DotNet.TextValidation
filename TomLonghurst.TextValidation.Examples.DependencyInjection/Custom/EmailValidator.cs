using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Examples.DependencyInjection.Custom.RegisterableInterfaces;
using TomLonghurst.TextValidation.Extensions;
using TomLonghurst.TextValidation.Predefined;

namespace TomLonghurst.TextValidation.Examples.DependencyInjection.Custom
{
    public class EmailValidator : IEmailValidator
    {
        private readonly ITextValidator _innerValidator = PredefinedTextValidation.IsEmailAddress.GetValidator();

        public bool IsValid(string input)
        {
            return _innerValidator.IsValid(input);
        }
    }
}