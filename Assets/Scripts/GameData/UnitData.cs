using System;
using UnityEngine;

[Serializable]
public class UnitData
{
    public readonly uint unitID;
    public Vector2Int size; // x: Right y: Down

    public UnitData()
    {
        unitID = GenerateUniqueID();
        size = new Vector2Int(1, 1);
    }

    private static uint GenerateUniqueID()
    {
        return 0;
    }
}
