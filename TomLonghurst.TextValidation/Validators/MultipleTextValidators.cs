using System.Collections.Generic;
using System.Linq;
using TomLonghurst.TextValidation.Contracts;
using TomLonghurst.TextValidation.Extensions;

namespace TomLonghurst.TextValidation.Validators
{
    public class MultipleTextValidators : ITextValidator, IWrappedValidators
    {
        private readonly IEnumerable<ITextValidator> _textValidators;

        public MultipleTextValidators(IEnumerable<ITextValidator> textValidators)
        {
            _textValidators = textValidators;
        }
        
        public MultipleTextValidators(params ITextValidator[] textValidators)
        {
            _textValidators = textValidators.UnwrapAll();
        }
        
        public bool IsValid(string input)
        {
            return _textValidators.All(validator => validator.IsValid(input));
        }

        public IEnumerable<ITextValidator> GetWrappedValidators()
        {
            return _textValidators;
        }
    }
}