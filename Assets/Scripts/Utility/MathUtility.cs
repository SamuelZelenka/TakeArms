using System.Runtime.CompilerServices;

namespace TakeArms.Utility
{
    public static class MathUtility
    {
        [MethodImpl]public static int WrapModulo(int value, int max) => (value % max + max) % max;
    }
}