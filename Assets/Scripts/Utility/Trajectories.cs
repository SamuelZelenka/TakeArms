using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TakeArms.Utility
{
    public static class Trajectories
    {
        public static Vector3 GetBezierPos(Vector3 start, Vector3 end, Vector3 startHandle, Vector3 endHandle, float t)
        {
            var p0 = -start * Mathf.Pow(t, 3) + 3 * start * Mathf.Pow(t, 2) - 3 * start * t + start;
            var p1 = 3 * startHandle * Mathf.Pow(t, 3) - 6 * startHandle * Mathf.Pow(t, 2) + 3 * startHandle * t;
            var p2 = -3 * endHandle * Mathf.Pow(t, 3) + 3 * endHandle * Mathf.Pow(t, 2);
            var p3 = end * Mathf.Pow(t, 3);

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
