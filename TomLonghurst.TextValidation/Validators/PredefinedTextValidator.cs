using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Predefined;

namespace TomLonghurst.TextValidation.Validators
{
    public class PredefinedTextValidator : ITextValidator
    {
        private readonly ITextValidator _textValidator;

        public PredefinedTextValidator(PredefinedTextValidation predefinedTextValidation)
        {
            _textValidator = PredefinedMapper.GetValidator(predefinedTextValidation);
        }
        
        public bool IsValid(string input)
        {
            return _textValidator.IsValid(input);
        }
    }
}