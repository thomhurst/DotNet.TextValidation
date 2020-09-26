using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Examples.DependencyInjection.Custom.RegisterableInterfaces;
// ReSharper disable SuggestBaseTypeForParameter

namespace TomLonghurst.TextValidation.Examples.DependencyInjection
{
    public class CustomInterfacesInjectedClass
    {
        public ITextValidator EmailValidator { get; }
        public ITextValidator NotNullOrEmptyValidator { get; }
        public ITextValidator LettersOnlyValidator { get; }

        public CustomInterfacesInjectedClass(IEmailValidator emailValidator,
            ILettersOnlyValidator lettersOnlyValidator,
            INotNullOrEmptyValidator notNullOrEmptyValidator)
        {
            EmailValidator = emailValidator;
            NotNullOrEmptyValidator = notNullOrEmptyValidator;
            LettersOnlyValidator = lettersOnlyValidator;
        }
    }
}