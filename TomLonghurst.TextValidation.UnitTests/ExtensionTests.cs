using System.Linq;
using NUnit.Framework;
using TomLonghurst.TextValidation.Extensions;
using TomLonghurst.TextValidation.Predefined;
using TomLonghurst.TextValidation.Validators;
using TomLonghurst.TextValidation.Validators.Async;

namespace TomLonghurst.TextValidation.UnitTests
{
    public class ExtensionTests
    {
        [Test]
        public void MultipleWrappedValidators()
        {
            var validator1 = PredefinedTextValidation.IsEmailAddress.GetValidator();
            var validator2 = PredefinedTextValidation.IsLettersOnly.GetValidator();

            var wrapper = validator1.Wrap(validator2);
            
            Assert.That(wrapper, Is.InstanceOf<MultipleTextValidators>());

            var innerValidators = ((MultipleTextValidators) wrapper).GetWrappedValidators().ToList();
            
            Assert.That(innerValidators[0], Is.InstanceOf<RegexTextValidator>());
            Assert.That(innerValidators[1], Is.InstanceOf<FunctionTextValidator>());
        }
        
        [Test]
        public void AsyncMultipleWrappedValidators()
        {
            var validator1 = new AsyncWrapTextValidator(PredefinedTextValidation.IsEmailAddress.GetValidator());
            var validator2 = new AsyncWrapTextValidator(PredefinedTextValidation.IsLettersOnly.GetValidator());

            var wrapper = validator1.WrapAsync(validator2);
            
            Assert.That(wrapper, Is.InstanceOf<AsyncMultipleTextValidators>());

            var innerValidators = ((AsyncMultipleTextValidators) wrapper).GetWrappedAsyncValidators().ToList();
            
            Assert.That(innerValidators[0], Is.InstanceOf<AsyncWrapTextValidator>());
            Assert.That(innerValidators[1], Is.InstanceOf<AsyncWrapTextValidator>());
            
            Assert.That(((AsyncWrapTextValidator)innerValidators[0]).GetWrappedValidators().First(), Is.InstanceOf<RegexTextValidator>());
            Assert.That(((AsyncWrapTextValidator)innerValidators[1]).GetWrappedValidators().First(), Is.InstanceOf<FunctionTextValidator>());
        }
    }
}