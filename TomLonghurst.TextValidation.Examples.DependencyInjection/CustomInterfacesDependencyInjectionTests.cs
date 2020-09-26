using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TomLonghurst.TextValidation.Examples.DependencyInjection.Custom;
using TomLonghurst.TextValidation.Examples.DependencyInjection.Custom.RegisterableInterfaces;

namespace TomLonghurst.TextValidation.Examples.DependencyInjection
{
    public class CustomInterfacesDependencyInjectionTests
    {
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<IEmailValidator, EmailValidator>()
                .AddSingleton<INotNullOrEmptyValidator, NotNullOrEmptyValidator>()
                .AddSingleton<ILettersOnlyValidator, LettersOnlyValidator>()
                .AddSingleton<CustomInterfacesInjectedClass>()
                .BuildServiceProvider();
        }

        [Test]
        public void CustomEmailValidatorInterfaceResolves()
        {
            var validator = _serviceProvider.GetService<IEmailValidator>();
            
            Assert.NotNull(validator);
            Assert.That(validator, Is.TypeOf<EmailValidator>());
        }
        
        [Test]
        public void CustomNotNullOrEmptyValidatorValidatorInterfaceResolves()
        {
            var validator = _serviceProvider.GetService<INotNullOrEmptyValidator>();
            
            Assert.NotNull(validator);
            Assert.That(validator, Is.TypeOf<NotNullOrEmptyValidator>());
        }
        
        [Test]
        public void CustomLettersOnlyValidatorValidatorInterfaceResolves()
        {
            var validator = _serviceProvider.GetService<ILettersOnlyValidator>();
            
            Assert.NotNull(validator);
            Assert.That(validator, Is.TypeOf<LettersOnlyValidator>());
        }

        [Test] 
        public void InjectedClass_ReceivesInjectedDependencies()
        {
            var injectedClass = _serviceProvider.GetService<CustomInterfacesInjectedClass>();
            
            var validator1 = injectedClass.EmailValidator;
            var validator2 = injectedClass.NotNullOrEmptyValidator;
            var validator3 = injectedClass.LettersOnlyValidator;
            
            Assert.NotNull(validator1);
            Assert.NotNull(validator2);
            Assert.NotNull(validator3);
            
            Assert.That(validator1, Is.TypeOf<EmailValidator>());
            Assert.That(validator2, Is.TypeOf<NotNullOrEmptyValidator>());
            Assert.That(validator3, Is.TypeOf<LettersOnlyValidator>());
        }
    }
}