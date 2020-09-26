using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Validators.Async;

namespace TomLonghurst.TextValidation.UnitTests.Async
{
    public class AsyncWrapTextValidatorTests
    {
        private Mock<ITextValidator> _synchronousTextValidator;
        
        private AsyncWrapTextValidator _asyncWrapTextValidator;

        [SetUp]
        public void Setup()
        {
            _synchronousTextValidator = new Mock<ITextValidator>();

            _asyncWrapTextValidator = new AsyncWrapTextValidator(_synchronousTextValidator.Object);
        }

        [Test]
        public async Task SynchronousValidatorReturningTrue_Then_AsynchronousWrapperReturnsTrue()
        {
            _synchronousTextValidator.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(true);

            var isValid = await _asyncWrapTextValidator.IsValidAsync("");
            
            Assert.True(isValid);
        }
        
        [Test]
        public async Task SynchronousValidatorReturningFalse_Then_AsynchronousWrapperReturnsFalse()
        {
            _synchronousTextValidator.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(false);

            var isValid = await _asyncWrapTextValidator.IsValidAsync("");
            
            Assert.False(isValid);
        }
    }
}