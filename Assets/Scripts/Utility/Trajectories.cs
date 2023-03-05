using UnityEngine;

namespace TakeArms.Utility
{
    public static class Trajectories
    {
        public static Vector3 GetBezierPos(Vector3 start, Vector3 end, Vector3 startHandle, Vector3 endHandle, float t)
        {
            var p0 = start * (1 - t) * (1 - t) * (1 - t);
            var p1 = 3 * startHandle * (1 - t) * (1 - t) * t;
            var p2 = 3 * endHandle * (1 - t) * t * t;
            var p3 = end * t * t * t;

            return p0 + p1 + p2 + p3;
        }

        public static Vector3 GetDerivative(Vector3 start, Vector3 end, Vector3 startHandle, Vector3 endHandle, float t)
        {
            var p0 = -3 * start * Mathf.Pow(t, 2) + 6 * start * t - 3 * start;
            var p1 = 9 * startHandle * Mathf.Pow(t, 2) - 12 * startHandle * t + 3 * startHandle;
            var p2 = -9 * endHandle * Mathf.Pow(t, 2) + 6 * endHandle * t;
            var p3 = 3 * end * Mathf.Pow(t, 2);

            Vector3 derivative;

            return p0 + p1 + p2 + p3;
        }
    }
}
