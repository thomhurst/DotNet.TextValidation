using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Validators.Async;

namespace TomLonghurst.TextValidation.UnitTests.Async
{
    public class AsyncMultipleTextValidatorsTests
    {
        private Mock<IAsyncTextValidator> _textValidator1;
        private Mock<IAsyncTextValidator> _textValidator2;
        
        private AsyncMultipleTextValidators _asyncMultipleTextValidators;

        [SetUp]
        public void Setup()
        {
            _textValidator1 = new Mock<IAsyncTextValidator>();
            _textValidator2 = new Mock<IAsyncTextValidator>();
            
            _asyncMultipleTextValidators = new AsyncMultipleTextValidators(_textValidator1.Object, _textValidator2.Object);
        }

        [Test]
        public async Task SynchronousValidatorsReturningTrue_Then_AsynchronousWrapperReturnsTrue()
        {
            _textValidator1.Setup(validator => validator.IsValidAsync(It.IsAny<string>()))
                .ReturnsAsync(true);
            
            _textValidator2.Setup(validator => validator.IsValidAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            var isValid = await _asyncMultipleTextValidators.IsValidAsync("");
            
            Assert.True(isValid);
        }
        
        [TestCase(false, true)]
        [TestCase(true, false)]
        public async Task SingleSynchronousValidatorReturningFalse_Then_AsynchronousWrapperReturnsFalse(bool validator1Result, bool validator2Result)
        {
            _textValidator1.Setup(validator => validator.IsValidAsync(It.IsAny<string>()))
                .ReturnsAsync(validator1Result);
            
            _textValidator2.Setup(validator => validator.IsValidAsync(It.IsAny<string>()))
                .ReturnsAsync(validator2Result);

            var isValid = await _asyncMultipleTextValidators.IsValidAsync("");
            
            Assert.False(isValid);
        }
        
        [Test]
        public async Task SynchronousValidatorsReturningFalse_Then_AsynchronousWrapperReturnsFalse()
        {
            _textValidator1.Setup(validator => validator.IsValidAsync(It.IsAny<string>()))
                .ReturnsAsync(false);
            
            _textValidator2.Setup(validator => validator.IsValidAsync(It.IsAny<string>()))
                .ReturnsAsync(false);

            var isValid = await _asyncMultipleTextValidators.IsValidAsync("");
            
            Assert.False(isValid);
        }
    }
}