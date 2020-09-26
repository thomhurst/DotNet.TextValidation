using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Validators;

namespace TomLonghurst.TextValidation.Predefined
{
    internal static class PredefinedMapper
    {
        private static readonly Dictionary<PredefinedTextValidation, ITextValidator> Validators = new Dictionary<PredefinedTextValidation, ITextValidator>();

        private static ITextValidator GetOrSet(PredefinedTextValidation predefinedTextValidation,
            Func<ITextValidator> setValidatorAction)
        {
            if (Validators.TryGetValue(predefinedTextValidation, out var validator))
            {
                return validator;
            }

            validator = setValidatorAction();
            
            Validators.Add(predefinedTextValidation, validator);

            return validator;
        } 
        
        internal static ITextValidator GetValidator(PredefinedTextValidation predefinedTextValidation)
        {
            switch (predefinedTextValidation)
            {
                case PredefinedTextValidation.IsEmailAddress:
                    return GetOrSet(predefinedTextValidation,
                        () => new RegexTextValidator(new Regex(
                            "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$")));
                case PredefinedTextValidation.IsNull:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(value => value == null));
                case PredefinedTextValidation.IsNullOrEmpty:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(string.IsNullOrEmpty));
                case PredefinedTextValidation.IsNullOrWhitespace:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(string.IsNullOrWhiteSpace));
                case PredefinedTextValidation.IsNotNull:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(value => value != null));
                case PredefinedTextValidation.IsNotNullOrEmpty:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(value => !string.IsNullOrEmpty(value)));
                case PredefinedTextValidation.IsNotNullOrWhitespace:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(value => !string.IsNullOrWhiteSpace(value)));
                case PredefinedTextValidation.IsLettersOnly:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(value => !string.IsNullOrWhiteSpace(value) && value.ToCharArray().All(char.IsLetter)));
                case PredefinedTextValidation.IsNumbersOnly:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(value => !string.IsNullOrWhiteSpace(value) && value.ToCharArray().All(char.IsDigit)));
                case PredefinedTextValidation.IsLettersOrNumbersOnly:
                    return GetOrSet(predefinedTextValidation, () => new FunctionTextValidator(value => !string.IsNullOrWhiteSpace(value) && value.ToCharArray().All(char.IsLetterOrDigit)));
                default:
                    throw new ArgumentOutOfRangeException(nameof(predefinedTextValidation), predefinedTextValidation, null);
            }
        }
    }
}