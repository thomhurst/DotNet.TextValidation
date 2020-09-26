using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using StructureMap;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Extensions;
using TomLonghurst.TextValidation.Predefined;
using TomLonghurst.TextValidation.Validators;

namespace TomLonghurst.TextValidation.Examples.DependencyInjection
{
    public class DependencyInjectionTests
    {
        private ServiceProvider _serviceProvider;
        private IContainer _textValidatorsContainer;

        [SetUp]
        public void Setup()
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.For<ITextValidator>().Add(PredefinedTextValidation.IsEmailAddress.GetValidator())
                    .Named("EmailValidator");
                config.For<ITextValidator>().Add(PredefinedTextValidation.IsNotNullOrEmpty.GetValidator())
                    .Named("NotNullOrEmptyValidator");
                config.For<ITextValidator>().Add(PredefinedTextValidation.IsLettersOnly.GetValidator())
                    .Named("LettersOnlyValidator");
            });

            _serviceProvider = new ServiceCollection()
                .AddSingleton<IContainer>(container)
                .AddSingleton<InjectedClass>()
                .BuildServiceProvider();

            _textValidatorsContainer = _serviceProvider.GetService<IContainer>();
        }

        [Test]
        public void CustomEmailValidatorInterfaceResolves()
        {
            var validator = _textValidatorsContainer.GetInstance<ITextValidator>("EmailValidator");
            
            Assert.NotNull(validator);
            Assert.That(validator, Is.TypeOf<RegexTextValidator>());
        }
        
        [Test]
        public void CustomNotNullOrEmptyValidatorValidatorInterfaceResolves()
        {
            var validator = _textValidatorsContainer.GetInstance<ITextValidator>("NotNullOrEmptyValidator");
            
            Assert.NotNull(validator);
            Assert.That(validator, Is.TypeOf<FunctionTextValidator>());
        }
        
        [Test]
        public void CustomLettersOnlyValidatorValidatorInterfaceResolves()
        {
            var validator = _textValidatorsContainer.GetInstance<ITextValidator>("LettersOnlyValidator");
            
            Assert.NotNull(validator);
            Assert.That(validator, Is.TypeOf<FunctionTextValidator>());
        }

        [Test] 
        public void InjectedClass_ReceivesInjectedDependencies()
        {
            var injectedClass = _serviceProvider.GetService<InjectedClass>();
            
            var validator1 = injectedClass.EmailValidator;
            var validator2 = injectedClass.NotNullOrEmptyValidator;
            var validator3 = injectedClass.LettersOnlyValidator;
            
            Assert.NotNull(validator1);
            Assert.NotNull(validator2);
            Assert.NotNull(validator3);
            
            Assert.That(validator1, Is.TypeOf<RegexTextValidator>());
            Assert.That(validator2, Is.TypeOf<FunctionTextValidator>());
            Assert.That(validator3, Is.TypeOf<FunctionTextValidator>());
        }
    }
}