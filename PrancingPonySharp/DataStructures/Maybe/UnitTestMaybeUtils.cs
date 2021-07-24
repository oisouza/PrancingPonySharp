namespace PrancingPonySharp.DataStructures.Maybe
{
    public static class UnitTestMaybeUtils
    {
        public static Maybe<T> Rewrap<T>(this T value) =>
            value;
    }
}
