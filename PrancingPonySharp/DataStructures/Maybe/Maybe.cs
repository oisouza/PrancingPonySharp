using System;

namespace PrancingPonySharp.DataStructures.Maybe
{
    public readonly struct Maybe<T>
    {
        private T Value { get; }

        public bool hasSomeValue { get; }

        public bool isNull => !hasSomeValue;

        public static implicit operator Maybe<T>(T value) =>
            Some(value);

        private Maybe(T value, bool hasSomeValue)
        {
            Value = value;
            this.hasSomeValue = hasSomeValue;
        }

        public static Maybe<TD> Some<TD>(TD value) => 
            new(value, value is not null);

        public TR Matches<TR>(Func<T, TR> some, Func<TR> or) =>
            hasSomeValue ? some(Value) : or();

        public void Matches(Action<T> some, Action or)
        {
            if (IsValue)
                some(Value);
            else
                or();
        }
    }
}
