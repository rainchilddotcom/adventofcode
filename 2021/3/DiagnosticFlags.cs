using System;

namespace _3
{
    [Flags]
    public enum DiagnosticFlags
    {
        Flag12 = 1 << 11,
        Flag11 = 1 << 10,
        Flag10 = 1 << 9,
        Flag9 = 1 << 8,
        Flag8 = 1 << 7,
        Flag7 = 1 << 6,
        Flag6 = 1 << 5,
        Flag5 = 1 << 4,
        Flag4 = 1 << 3,
        Flag3 = 1 << 2,
        Flag2 = 1 << 1,
        Flag1 = 1 << 0
    }
}
