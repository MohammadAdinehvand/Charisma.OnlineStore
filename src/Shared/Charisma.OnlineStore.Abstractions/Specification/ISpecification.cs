using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Abstractions.Specification
{
    public interface ISpecification<in T>
    {
        ValueTask<bool> IsSatisfiedBy(T entity);
        string ErrorMessage { get; }
    }
}
