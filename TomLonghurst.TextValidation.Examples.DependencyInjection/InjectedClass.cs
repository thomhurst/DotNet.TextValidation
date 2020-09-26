using StructureMap;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Examples.DependencyInjection.CustomRegisterableInterfaces;

namespace TomLonghurst.TextValidation.Examples.DependencyInjection
{
    public class InjectedClass
    {
        public ITextValidator EmailValidator { get; }
        public ITextValidator NotNullOrEmptyValidator { get; }
        public ITextValidator LettersOnlyValidator { get; }

        public InjectedClass(IContainer container)
        {
            EmailValidator = container.GetInstance<ITextValidator>("EmailValidator");
            NotNullOrEmptyValidator = container.GetInstance<ITextValidator>("NotNullOrEmptyValidator");
            LettersOnlyValidator = container.GetInstance<ITextValidator>("LettersOnlyValidator");
        }
    }
}