using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class UnitData
{
    public ulong ID;
    public Vector2Int size; // x: Right y: Down

    public UnitData()
    {
        size = new Vector2Int(1, 1);
    }
}
