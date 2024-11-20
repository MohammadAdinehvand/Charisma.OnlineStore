using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Abstractions.Domain
{
    public class DomainException : Exception
    {
        private List<string> _messages = new();


        public IReadOnlyList<string> Messages { get { return _messages.AsReadOnly(); } }
        public DomainException(string message) : base(message)
        {
            _messages.Add(message);
        }

        public DomainException(List<string> messages) : base(string.Join(",", messages))
        {
            _messages.AddRange(messages);
        }
    }
}
