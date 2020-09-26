using StructureMap;
using TomLonghurst.TextValidation.Contracts;

namespace TomLonghurst.TextValidation.Examples.DependencyInjection
{
    public class NamedServicesInjectedClass
    {
        public ITextValidator EmailValidator { get; }
        public ITextValidator NotNullOrEmptyValidator { get; }
        public ITextValidator LettersOnlyValidator { get; }

        public NamedServicesInjectedClass(IContainer container)
        {
            EmailValidator = container.GetInstance<ITextValidator>("EmailValidator");
            NotNullOrEmptyValidator = container.GetInstance<ITextValidator>("NotNullOrEmptyValidator");
            LettersOnlyValidator = container.GetInstance<ITextValidator>("LettersOnlyValidator");
        }
    }
}