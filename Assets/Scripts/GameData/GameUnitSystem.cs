using System.Collections;
using System.Collections.Generic;
using TakeArms.GameUnits;
using TakeArms.GameData;
using UnityEngine;

public class GameUnitSystem
{
    private static Dictionary<int, GameUnitStatus> _gameUnits = new Dictionary<int, GameUnitStatus>();

    public static void MoveUnit(int id)
    {

    }

    public static void AddUnit(int id, UnitData data)
    {

    }

    public static int GetGameUnitAt(Vector2Int coordinate)
    {
        foreach (var unit in _gameUnits)
        {
            if (unit.Value.boardPosition == coordinate)
            {
                return unit.Key;
            }
        }
        return -1;
    }

}
