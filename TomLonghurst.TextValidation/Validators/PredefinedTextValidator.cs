using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Predefined;

namespace TomLonghurst.TextValidation.Validators
{
    public class PredefinedTextValidator : ITextValidator
    {
        private readonly PredefinedTextValidation _predefinedTextValidation;

        public PredefinedTextValidator(PredefinedTextValidation predefinedTextValidation)
        {
            _predefinedTextValidation = predefinedTextValidation;
        }
        
        public bool IsValid(string input)
        {
            return PredefinedMapper.GetValidator(_predefinedTextValidation).IsValid(input);
        }
    }
}