using System.Collections.Generic;
using System.Linq;
using TomLonghurst.TextValidation.Contracts;

namespace TomLonghurst.TextValidation.Validators
{
    public class MultipleTextValidators : ITextValidator
    {
        private readonly IEnumerable<ITextValidator> _textValidators;

        public MultipleTextValidators(IEnumerable<ITextValidator> textValidators)
        {
            _textValidators = textValidators;
        }
        
        public MultipleTextValidators(params ITextValidator[] textValidators)
        {
            _textValidators = textValidators;
        }
        
        public bool IsValid(string input)
        {
            return _textValidators.All(validator => validator.IsValid(input));
        }
    }
}