using System.Text.RegularExpressions;
using NUnit.Framework;
using TomLonghurst.TextValidation.Validators;

namespace TomLonghurst.TextValidation.UnitTests
{
    public class RegexTextValidatorTests
    {
        private RegexTextValidator _regexTextValidator;

        [Test]
        public void SynchronousValidatorReturningTrue_Then_AsynchronousWrapperReturnsTrue()
        {
            _regexTextValidator = new RegexTextValidator(new Regex(".*"));

            var isValid = _regexTextValidator.IsValid("");
            
            Assert.True(isValid);
        }
        
        [Test]
        public void SynchronousValidatorReturningFalse_Then_AsynchronousWrapperReturnsFalse()
        {
            _regexTextValidator = new RegexTextValidator(new Regex(".+"));

            var isValid = _regexTextValidator.IsValid("");
            
            Assert.False(isValid);
        }
    }
}