using System;
using TakeArms.Configurations;
using UnityEditor;
using UnityEngine;

namespace TakeArms.GameUnits
{
    [Serializable]
    public class GameUnitStatus
    {
        public GameUnitStatus(GameObject instance, Vector2Int coordinate)
        {
            _unitInstance = instance;
            boardPosition = coordinate;

        }
        private GameObject _unitInstance;
        public GameObject Instance => _unitInstance;
        public enum UnitHealth { Alive, Wounded, Dead, None}
        public UnitHealth health;
        public Vector2Int boardPosition;
    }
}
