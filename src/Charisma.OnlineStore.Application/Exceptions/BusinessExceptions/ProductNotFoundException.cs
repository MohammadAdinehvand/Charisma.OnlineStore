using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Application.Exceptions.BusinessExceptions
{
    public class ProductNotFoundException : ApplicationException
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
