using System.Collections.Generic;
using System.Linq;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Validators;
using TomLonghurst.TextValidation.Validators.Async;

namespace TomLonghurst.TextValidation.Extensions
{
    public static class AsyncWrapExtensions
    {
        public static IAsyncTextValidator WrapAsync(this IAsyncTextValidator textValidator, IAsyncTextValidator otherTextValidator)
        {
            return new AsyncMultipleTextValidators(textValidator, otherTextValidator);
        }
        
        public static IAsyncTextValidator WrapAsync(this IAsyncTextValidator textValidator, ITextValidator otherTextValidator)
        {
            return new AsyncMultipleTextValidators(textValidator, new AsyncWrapTextValidator(otherTextValidator));
        }

        internal static IEnumerable<IAsyncTextValidator> UnwrapAllAsync(this IEnumerable<IAsyncTextValidator> textValidators)
        {
            return textValidators.SelectMany(UnwrapAllAsync);
        }

        internal static IEnumerable<IAsyncTextValidator> UnwrapAllAsync(this IAsyncTextValidator textValidator)
        {
            if (textValidator is IAsyncWrappedValidator wrappedValidators)
            {
                var wrapped = wrappedValidators.GetWrappedAsyncValidators();

                foreach (var validator in UnwrapAllAsync(wrapped))
                {
                    yield return validator;
                }
            }

            yield return textValidator;
        }
    }
}