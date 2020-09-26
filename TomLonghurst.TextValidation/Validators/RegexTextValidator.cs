using System.Text.RegularExpressions;
using TomLonghurst.TextValidation.Contracts;

namespace TomLonghurst.TextValidation.Validators
{
    public class RegexTextValidator : ITextValidator
    {
        private readonly Regex _regex;

        public RegexTextValidator(Regex regex)
        {
            _regex = regex;
        }

        public bool IsValid(string input)
        {
            return _regex.Match(input).Success;
        }
    }
}