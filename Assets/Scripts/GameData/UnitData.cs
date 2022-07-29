using System;
using UnityEngine;

namespace TakeArms.GameData
{
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
}
