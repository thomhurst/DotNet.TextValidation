using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Predefined;

namespace TomLonghurst.TextValidation.Extensions
{
    public static class PredefinedTextValidationExtensions
    {
        public static ITextValidator GetValidator(this PredefinedTextValidation predefinedTextValidation)
        {
            return PredefinedMapper.GetValidator(predefinedTextValidation);
        }
    }
}