namespace PrancingPonySharp.DataStructures.Maybe
{
    public static class MaybeUtils
    {
        public static Maybe<T> Rewrap<T>(this T value) =>
            value;
    }
}
