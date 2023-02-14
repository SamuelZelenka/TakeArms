using System;
using UnityEngine;

namespace TakeArms.GameData
{
    [Serializable]
    public abstract class UnitData
    {
        public ulong ID;
        public Vector2Int size;

        public UnitData()
        {
            size = new Vector2Int(1, 1);
        }
    }
}
