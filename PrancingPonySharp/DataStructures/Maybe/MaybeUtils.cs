namespace PrancingPonySharp.DataStructures.Maybe
{
    public static class MaybeUtils
    {
        public static Maybe<T> Maybe<T>(this T value) =>
            value;
    }
}
