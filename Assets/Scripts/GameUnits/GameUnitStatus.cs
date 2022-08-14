using System;
using TakeArms.Configurations;
using UnityEditor;
using UnityEngine;

namespace TakeArms.GameUnits
{
    [Serializable]
    public class GameUnitStatus
    {
        public readonly ulong configID;
        public enum UnitHealth { Alive, Wounded, Dead, None}
        public UnitHealth health;
        public Vector2Int boardPosition;
    }
}