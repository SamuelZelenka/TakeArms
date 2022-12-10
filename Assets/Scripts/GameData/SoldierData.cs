using System;
using UnityEngine;

namespace TakeArms.GameData
{
    [Serializable]
    public class SoldierData : UnitData
    {
        public bool isWounded;
        public Vector2Int position;
    }
}
