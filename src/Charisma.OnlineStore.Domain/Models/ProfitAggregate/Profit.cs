using Charisma.OnlineStore.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Models.ProfitAggregate
{
    public class Profit : Entity<int>, IAggregateRoot
    {

        public Profit(string title, decimal fixedAmount, bool active = false)
        {
            _title = title;
            _fixedAmount = fixedAmount;
            Active = active;
        }

        private string _title;
        private decimal _fixedAmount; 
        public bool Active { get;private set; }
        private Profit()
        {
            
        }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }

        public decimal Calculate()
        {
            if (!Active)
            {
                return 0; // اگر غیرفعال باشد سودی محاسبه نمی‌شود
            }

            return _fixedAmount;
        }
    }
}
