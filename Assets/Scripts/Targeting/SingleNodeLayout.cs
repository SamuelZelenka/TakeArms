using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.TargetVisualizers
{
    public class SingleNodeLayout : TargetLayout
    {
        public override Vector2Int[] GetTargetCoordinates(Vector3 worldPos)
        {
            targetCoordinates = new List<Vector2Int>();
            targetCoordinates.Add(new Vector2Int((int) worldPos.x, (int) worldPos.z));
            return targetCoordinates.ToArray();
        }
    }
}