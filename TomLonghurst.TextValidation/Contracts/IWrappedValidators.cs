using System.Collections.Generic;

namespace TomLonghurst.TextValidation.Contracts
{
    public interface IWrappedValidators
    {
        IEnumerable<ITextValidator> GetWrappedValidators();
    }
}