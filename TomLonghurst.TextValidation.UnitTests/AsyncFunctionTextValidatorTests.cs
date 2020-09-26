using NUnit.Framework;
using TomLonghurst.TextValidation.Validators;

namespace TomLonghurst.TextValidation.UnitTests
{
    public class FunctionTextValidatorTests
    {
        private FunctionTextValidator _functionTextValidator;

        [Test]
        public void SynchronousValidatorReturningTrue_Then_AsynchronousWrapperReturnsTrue()
        {
            _functionTextValidator = new FunctionTextValidator(value => value == "");

            var isValid = _functionTextValidator.IsValid("");
            
            Assert.True(isValid);
        }
        
        [Test]
        public void SynchronousValidatorReturningFalse_Then_AsynchronousWrapperReturnsFalse()
        {
            _functionTextValidator = new FunctionTextValidator(value => value != "");

            var isValid = _functionTextValidator.IsValid("");
            
            Assert.False(isValid);
        }
    }
}