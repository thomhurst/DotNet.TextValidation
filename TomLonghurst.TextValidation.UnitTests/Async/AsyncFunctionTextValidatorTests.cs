using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Validators.Async;

namespace TomLonghurst.TextValidation.UnitTests.Async
{
    public class AsyncFunctionTextValidatorTests
    {
        private AsyncFunctionTextValidator _asyncFunctionTextValidator;

        [Test]
        public async Task SynchronousValidatorReturningTrue_Then_AsynchronousWrapperReturnsTrue()
        {
            _asyncFunctionTextValidator = new AsyncFunctionTextValidator(value => Task.FromResult(value == ""));

            var isValid = await _asyncFunctionTextValidator.IsValidAsync("");
            
            Assert.True(isValid);
        }
        
        [Test]
        public async Task SynchronousValidatorReturningFalse_Then_AsynchronousWrapperReturnsFalse()
        {
            _asyncFunctionTextValidator = new AsyncFunctionTextValidator(value => Task.FromResult(value != ""));

            var isValid = await _asyncFunctionTextValidator.IsValidAsync("");
            
            Assert.False(isValid);
        }
    }
}