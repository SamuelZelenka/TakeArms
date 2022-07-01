using System.Collections.Generic;
using UnityEngine;

public abstract class TargetLayout
{    
    protected List<Vector2Int> targetCoordinates = new List<Vector2Int>();
    public virtual Vector2Int[] GetTargetCoordinates() => targetCoordinates.ToArray();
}
