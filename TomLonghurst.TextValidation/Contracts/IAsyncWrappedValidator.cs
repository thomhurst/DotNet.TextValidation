using System.Collections.Generic;

namespace TomLonghurst.TextValidation.Contracts
{
    public interface IAsyncWrappedValidator
    {
        IEnumerable<IAsyncTextValidator> GetWrappedAsyncValidators();
    }
}