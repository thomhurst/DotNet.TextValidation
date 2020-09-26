using System.Collections.Generic;
using System.Linq;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Validators;

namespace TomLonghurst.TextValidation.Extensions
{
    public static class WrapExtensions
    {
        public static ITextValidator Wrap(this ITextValidator textValidator, ITextValidator otherTextValidator)
        {
            return new MultipleTextValidators(textValidator, otherTextValidator);
        }

        internal static IEnumerable<ITextValidator> UnwrapAll(this IEnumerable<ITextValidator> textValidators)
        {
            return textValidators.SelectMany(UnwrapAll);
        }

        private static IEnumerable<ITextValidator> UnwrapAll(this ITextValidator textValidator)
        {
            if (textValidator is IWrappedValidators wrappedValidators)
            {
                var wrapped = wrappedValidators.GetWrappedValidators();

                foreach (var validator in UnwrapAll(wrapped))
                {
                    yield return validator;
                }
            }

            yield return textValidator;
        }
    }
}