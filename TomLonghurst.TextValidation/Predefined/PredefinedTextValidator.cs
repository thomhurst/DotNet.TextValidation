using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Extensions;

namespace TomLonghurst.TextValidation.Predefined
{
    public static class PredefinedTextValidator
    {
        public static ITextValidator Get(PredefinedTextValidation predefinedTextValidation)
        {
            return predefinedTextValidation.GetValidator();
        }
    }
}