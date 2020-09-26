using NUnit.Framework;
using TomLonghurst.TextValidation.Predefined;
using TomLonghurst.TextValidation.Validators;

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
            var isValid = new PredefinedTextValidator(PredefinedTextValidation.IsEmailAddress).IsValid(emailAddress);
            
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
            var isValid = new PredefinedTextValidator(PredefinedTextValidation.IsEmailAddress).IsValid(emailAddress);

            Assert.False(isValid);
        }

        [TestCase(null, true)]
        [TestCase("", false)]
        public void IsNull_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = new PredefinedTextValidator(PredefinedTextValidation.IsNull).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase(" ", false)]
        [TestCase("blah", false)]
        public void IsNullOrEmpty_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = new PredefinedTextValidator(PredefinedTextValidation.IsNullOrEmpty).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
        
        [TestCase(null, true)]
        [TestCase("", true)]
        [TestCase(" ", true)]
        [TestCase("blah", false)]
        public void IsNullOrWhitespace_ReturnsCorrectResult(string input, bool expectedIsValid)
        {
            var isValid = new PredefinedTextValidator(PredefinedTextValidation.IsNullOrWhitespace).IsValid(input);

            Assert.That(isValid, Is.EqualTo(expectedIsValid));
        }
    }
}