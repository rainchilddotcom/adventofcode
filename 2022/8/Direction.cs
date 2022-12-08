namespace _8
{
    public enum Direction
    {
        North = 1 << 0,
        West = 1 << 1,
        South = 1 << 2,
        East = 1 << 3,

        None = 0,
        All = North | South | East | West
    }
}
