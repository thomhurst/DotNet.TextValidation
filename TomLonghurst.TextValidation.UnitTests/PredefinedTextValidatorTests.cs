using NUnit.Framework;
using TomLonghurst.TextValidation.Predefined;

namespace TomLonghurst.TextValidation.UnitTests
{
    public class PredefinedTextValidatorTests
    {
        [TestCase("mkyong@yahoo.com")]
        [TestCase("mkyong-100@yahoo.com")]
        [TestCase("mkyong.100@yahoo.com")]
        [TestCase("mkyong111@mkyong.com")]
        [TestCase("mkyong-100@mkyong.net")]
        [TestCase("mkyong.100@mkyong.com.au")] 
        [TestCase("mkyong@1.com")]
        [TestCase("mkyong@gmail.com.com")]
        [TestCase("mkyong+100@gmail.com")]
        [TestCase("mkyong-100@yahoo-test.com")]
        public void Valid_Email_Returns_True(string emailAddress)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsEmailAddress).IsValid(emailAddress);
            
            Assert.True(isValid);
        }
        
        [TestCase("mkyong")]
        [TestCase("mkyong@.com.my")] 
        [TestCase("mkyong123@gmail.a")]
        [TestCase("mkyong123@.com")] 
        [TestCase("mkyong123@.com.com")]
        [TestCase(".mkyong@mkyong.com")] 
        [TestCase("mkyong()*@gmail.com")]
        [TestCase("mkyong@%*.com")] 
        [TestCase("mkyong..2002@gmail.com")]
        [TestCase("mkyong.@gmail.com")] 
        [TestCase("mkyong@mkyong@gmail.com")]
        public void Invalid_Email_Returns_False(string emailAddress)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsEmailAddress).IsValid(emailAddress);

            Assert.False(isValid);
        }

        [TestCase(null, true)]
        [TestCase("", false)]
        public void IsNull_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsNull).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase(null, false)]
        [TestCase("", true)]
        public void IsNotNull_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsNotNull).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase(" ", false)]
        [TestCase("blah", false)]
        public void IsNullOrEmpty_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsNullOrEmpty).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", true)]
        [TestCase("blah", true)]
        public void IsNotNullOrEmpty_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsNotNullOrEmpty).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase(" ", true)]
        [TestCase("blah", false)]
        public void IsNullOrWhitespace_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsNullOrWhitespace).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("blah", true)]
        public void IsNotNullOrWhitespace_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsNotNullOrWhitespace).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase("", false)]
        [TestCase("Blah", false)]
        [TestCase("Blah123", false)]
        [TestCase(" ", false)]
        [TestCase("123", true)]
        public void IsNumbersOnly_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsNumbersOnly).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase("", false)]
        [TestCase("Blah", true)]
        [TestCase("Blah123", true)]
        [TestCase(" ", false)]
        [TestCase("123", true)]
        public void IsNumbersOrLettersOnly_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsLettersOrNumbersOnly).IsValid(input);
            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase("", false)]
        [TestCase("Blah", true)]
        [TestCase("Blah123", false)]
        [TestCase(" ", false)]
        [TestCase("123", false)]
        public void IsLettersOnly_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = PredefinedTextValidator.Get(PredefinedTextValidation.IsLettersOnly).IsValid(input);
            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
    }
}