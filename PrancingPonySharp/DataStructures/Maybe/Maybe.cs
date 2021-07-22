using System;

namespace PrancingPonySharp.DataStructures.Maybe
{
    public readonly struct Maybe<T>
    {
        private T Value { get; }

        public bool IsValue { get; }

        public bool IsNull => !IsValue;

        public static implicit operator Maybe<T>(T value) =>
            A(value);

        private Maybe(T value, bool isValue)
        {
            Value = value;
            this.IsValue = isValue;
        }

        public static Maybe<TD> A<TD>(TD value) => 
            new(value, value is not null);

        public TR Matches<TR>(Func<T, TR> a, Func<TR> or) =>
            IsValue ? a(Value) : or();

        public void Matches(Action<T> a, Action or)
        {
            if (IsValue)
                a(Value);
            else
                or();
        }
    }
}
