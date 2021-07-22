using System;

namespace PrancingPonySharp.DataStructures.Maybe
{
    public readonly struct Maybe<T>
    {
        private T Value { get; }

        public bool IsJust { get; }

        public bool IsNothing => !IsJust;

        public static implicit operator Maybe<T>(T value) =>
            Just(value);

        private Maybe(T value, bool isJust)
        {
            Value = value;
            IsJust = isJust;
        }

        public static Maybe<TD> Just<TD>(TD value) => 
            new(value, value is not null);

        public TR Match<TR>(Func<T, TR> just, Func<TR> nothing) => 
            IsJust ? just(Value) : nothing();

        public void Match(Action<T> just, Action nothing)
        {
            if (IsJust)
                just(Value);
            else
                nothing();
        }
    }
}
