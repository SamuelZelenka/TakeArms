using System;
using UnityEngine;

[Serializable]
public class UnitData
{
    public readonly int unitID;
    public Vector2Int size; // x: Right y: down
    public Vector2Int tile;
    public Vector2Int positionOnTile;
}
