using Moq;
using NUnit.Framework;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Validators;

namespace TomLonghurst.TextValidation.UnitTests
{
    public class MultipleTextValidatorsTests
    {
        private Mock<ITextValidator> _textValidator1;
        private Mock<ITextValidator> _textValidator2;
        
        private MultipleTextValidators _multipleTextValidators;

        [SetUp]
        public void Setup()
        {
            _textValidator1 = new Mock<ITextValidator>();
            _textValidator2 = new Mock<ITextValidator>();
            
            _multipleTextValidators = new MultipleTextValidators(_textValidator1.Object, _textValidator2.Object);
        }

        [Test]
        public void AllChildValidatorsReturningTrue_ReturnsTrue()
        {
            _textValidator1.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(true);
            _textValidator2.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(true);

            var isValid = _multipleTextValidators.IsValid("");
            
            Assert.True(isValid);
        }
        
        [Test]
        public void AllChildValidatorsReturningFalse_ReturnsFalse()
        {
            _textValidator1.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(false);
            _textValidator2.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(false);

            var isValid = _multipleTextValidators.IsValid("");
            
            Assert.False(isValid);
        }
        
        [Test]
        public void OneChildValidatorReturningFalse_ReturnsFalse()
        {
            _textValidator1.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(true);
            _textValidator2.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(false);

            var isValid = _multipleTextValidators.IsValid("");
            
            Assert.False(isValid);
        }
    }
}