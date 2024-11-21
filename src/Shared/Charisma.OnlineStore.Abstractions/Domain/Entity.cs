#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Abstractions.Domain
{
    public abstract class Entity<T>
    {
        T _Id;
        public virtual T Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }


        public IEnumerable<IDomainEvent> Events => _events;
        private readonly List<IDomainEvent> _events = new();
        private bool _versionIncremented;

        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any() && !_versionIncremented)
            {
                _versionIncremented = true;
                _events.Add(@event);

            }
        }
        public void ClearEvents() => _events.Clear();
        protected void IncrementVersion()
        {
            if (_versionIncremented)
            {
                return;

            }
            _versionIncremented = true;
        }


        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }
    }
}
