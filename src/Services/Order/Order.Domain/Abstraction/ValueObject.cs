using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Domain.Abstraction
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        //protected static bool EqualOperator(ValueObject left, ValueObject right)
        //{
        //    if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        //    {
        //        return false;
        //    }
        //    return ReferenceEquals(left, null) || left.Equals(right);
        //}

        private bool ValuesAreEqual(ValueObject other)
        {
            return GetAtomicValue().SequenceEqual(other.GetAtomicValue());
        }

        //protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        //{
        //    return !(EqualOperator(left, right));
        //}

        protected abstract IEnumerable<object> GetAtomicValue();

        public override bool Equals(object obj)
        {
            return obj is ValueObject other && ValuesAreEqual(other);
           
        }

        public override int GetHashCode()
        {
            return GetAtomicValue()
                .Aggregate(default(int),HashCode.Combine);
        }

        public bool Equals(ValueObject other)
        {
            return other is not null && ValuesAreEqual(other);
        }
        // Other utility methods
    }
}
