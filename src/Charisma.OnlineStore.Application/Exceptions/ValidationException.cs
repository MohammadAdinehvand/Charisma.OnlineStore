using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Application.Exceptions
{
    public sealed class ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary) : ApplicationException("One or more validation errors occurred")
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; } = errorsDictionary;
    }
}
