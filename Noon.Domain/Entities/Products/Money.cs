using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Products
{
    public class Money : IEquatable<Money>
    {
        // Properties
        public decimal Amount { get; }
        public string Currency { get; }

        // Constructor
        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        // Equality check
        public override bool Equals(object obj)
        {
            return Equals((Money)obj);
        }

        public bool Equals(Money other)
        {
            return other != null &&
                   Amount == other.Amount &&
                   Currency == other.Currency;
        }

        // Override GetHashCode for consistency with Equals
        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }
    }

}
