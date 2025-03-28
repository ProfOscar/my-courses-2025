using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCourses.Models.Enums;

namespace MyCourses.Models
{
    public class Money
    {
        public Money() : this(Currency.EUR, 0.00m) { }
        public Money(Currency c, decimal a)
        {
            Currency = c;
            Amount = a;
        }

        private decimal _amount = 0;
        public decimal Amount { 
            get { return _amount; } 
            set {
                if (value < 0)
                    throw new InvalidOperationException("The amount cannot be negative");
                _amount = value; 
            } 
        }
        
        public Currency Currency { get; set; }

        public override bool Equals(object? obj)
        {
            var other = obj as Money;
            return other != null && 
                other.Amount == Amount && 
                other.Currency == Currency; 
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public override string ToString()
        {
            return $"{Currency} {Amount:#.00}";
        }
    }
}
