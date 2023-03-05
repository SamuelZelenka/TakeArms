using System.Collections.Generic;
using TakeArms.GameUnits;
using UnityEngine;
using TakeArms.Configurations;
using TakeArms.Services;

namespace TakeArms.Systems
{
    public class GameUnitSystem
    {
        private static Dictionary<ulong, GameUnitStatus> _gameUnits = new Dictionary<ulong, GameUnitStatus>();

        public static void MoveUnit(ulong id, Vector2Int coordinate)
        {
            var unit = _gameUnits[id];
            unit.boardPosition = coordinate;
            unit.Instance.transform.position = GameBoard.GetWorldPosFromBoardPos(coordinate);
        }

        public static void SpawnUnit(UnitConfiguration config, Vector2Int coordinate)
        {
            if (GetGameUnitAt(coordinate) != 0)
                return;

            var newUnit = Object.Instantiate(config.prefab);
            var newUnitStatus = new GameUnitStatus(newUnit, coordinate);
            var uniqueId = RepositoryService.GetUniqueID(_gameUnits);

            _gameUnits.Add(uniqueId, newUnitStatus);
            MoveUnit(uniqueId, coordinate);
        }

        public static ulong GetGameUnitAt(Vector2Int coordinate)
        {
            foreach (var unit in _gameUnits)
            {
                if (unit.Value.boardPosition == coordinate)
                {
                    return unit.Key;
                }
            }
            return 0;
        }
    }
}
